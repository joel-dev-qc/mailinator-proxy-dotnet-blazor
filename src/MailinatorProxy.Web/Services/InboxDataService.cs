using MailinatorProxy.Shared.Dtos.Mails;
using MailinatorProxy.Web.ApiClients;
using MailinatorProxy.Web.States;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MailinatorProxy.Web.Services;



internal sealed class InboxDataService(
    IMalinatorApiClient mailinatorApiClient,
    MailReadState mailReadStateService,
    ILogger<InboxDataService> logger,
    ISnackbar snackbar,
    IStringLocalizer<InboxDataService> localizer,
    InboxListState inboxListState)
    : IInboxDataService, IDisposable
{
    private readonly SemaphoreSlim _operationLock = new(1, 1);
    private bool _disposed;

    public async Task<(List<MessageDto> Messages, bool HasMoreData)> LoadInboxDataAsync(string domain, string inbox, int offset, int pageSize, bool forceReload = false)
    {
        await _operationLock.WaitAsync();
        try
        {
            var domainState = inboxListState.GetOrCreateDomainState(domain);

            // Verified if we already have messages loaded for this inbox and if it's not a forced reload
            if (offset == 0 && domainState.Messages.Count > 0 && domainState.CurrentInbox == inbox && !forceReload)
            {
                // Return cached messages
                return (domainState.Messages, domainState.HasMoreData);
            }

            // Load 1 more than the page size to check if there are more messages
            int fetchCount = pageSize + 1;
            var messages = await LoadInboxMessagesAsync(domain, inbox, offset, fetchCount);

            bool hasMoreData = messages.Count > pageSize;
            if (hasMoreData)
            {
                messages = messages.Take(pageSize).ToList();
            }

            if (offset == 0)
            {
                // Initial Load - Replace existing messages
                domainState.Messages = new List<MessageDto>(messages);
            }
            else
            {
                // Loading more messages - Deduplicate and append
                domainState.Messages = DeduplicateAndAppend(domainState.Messages, messages);
            }

            domainState.CurrentOffset = offset + messages.Count;
            domainState.HasMoreData = hasMoreData;
            domainState.CurrentInbox = inbox;

            return (domainState.Messages, domainState.HasMoreData);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erreur lors du chargement des données de la boîte de réception");
            snackbar.Add(localizer["Inbox_LoadError"], Severity.Error);
            var domainState = inboxListState.GetOrCreateDomainState(domain);
            return (domainState.Messages, domainState.HasMoreData);
        }
        finally
        {
            _operationLock.Release();
        }
    }

    public async Task<List<MessageDto>> CheckForNewMessagesAsync(string domain, string inbox, int limit)
    {
        await _operationLock.WaitAsync();
        try
        {
            var domainState = inboxListState.GetOrCreateDomainState(domain);
            var latestMessages = await LoadInboxMessagesAsync(domain, inbox, 0, limit);

            // Identifier les nouveaux messages
            var currentIds = new HashSet<string>(domainState.Messages.Select(m => m.Id));
            var newMessages = latestMessages.Where(m => !currentIds.Contains(m.Id)).ToList();

            // Ajouter les nouveaux messages au début
            if (newMessages.Count > 0)
            {
                domainState.Messages.InsertRange(0, newMessages);
                domainState.Messages = domainState.Messages.OrderByDescending(m => m.Time).ToList();
            }

            return newMessages;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erreur lors de la vérification des nouveaux messages");
            snackbar.Add(localizer["Inbox_LoadError"], Severity.Error);
            return [];
        }
        finally
        {
            _operationLock.Release();
        }
    }

    public async Task<bool> DeleteMessageAsync(string domain, string inbox, string messageId)
    {
        await _operationLock.WaitAsync();
        try
        {
            await mailinatorApiClient.DeleteMailByIdAsync(domain, inbox, messageId);

            // Ensure we remove the message from the state
            var domainState = inboxListState.GetOrCreateDomainState(domain);
            domainState.Messages.RemoveAll(m => m.Id == messageId);

            await mailReadStateService.RemoveAsync(domain, messageId);

            snackbar.Add(localizer["MessageDeleted_Info"], Severity.Info);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while deleting the message");
            snackbar.Add(localizer["MessageDelete_Error"], Severity.Error);
            return false;
        }
        finally
        {
            _operationLock.Release();
        }
    }

    public bool IsMessageUnread(string domain, string messageId)
    {
        var domainState = inboxListState.GetOrCreateDomainState(domain);
        return domainState.ReadStates.TryGetValue(messageId, out var isRead) && !isRead;
    }

    public string GetCurrentInbox(string domain)
    {
        var domainState = inboxListState.GetOrCreateDomainState(domain);
        return string.IsNullOrWhiteSpace(domainState.CurrentInbox) ? "*" : domainState.CurrentInbox;
    }

    public void SetCurrentInbox(string domain, string inbox)
    {
        var domainState = inboxListState.GetOrCreateDomainState(domain);
        domainState.CurrentInbox = inbox;
    }

    public void ClearState(string domain)
    {
        inboxListState.ClearState(domain);
    }

    public List<MessageDto> GetCurrentMessages(string domain)
    {
        return inboxListState.GetOrCreateDomainState(domain).Messages;
    }

    public bool HasMoreData(string domain)
    {
        return inboxListState.GetOrCreateDomainState(domain).HasMoreData;
    }

    private async Task<List<MessageDto>> LoadInboxMessagesAsync(string domain, string inbox, int skip, int limit)
    {
        var result = await mailinatorApiClient.GetMailInboxAsync(domain, inbox, skip: skip, limit: limit);
        var domainState = inboxListState.GetOrCreateDomainState(domain);

        foreach (var msg in result.Messages)
        {
            domainState.ReadStates[msg.Id] = await mailReadStateService.IsReadAsync(domain, msg.Id);
        }

        return result.Messages;
    }

    private static List<MessageDto> DeduplicateAndAppend(List<MessageDto> source, List<MessageDto> toAppend)
    {
        var existingIds = source.Select(m => m.Id).ToHashSet();
        var newItems = toAppend.Where(m => !existingIds.Contains(m.Id)).ToList();
        source.AddRange(newItems);
        return source.OrderByDescending(m => m.Time).ToList();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _operationLock.Dispose();
        }

        _disposed = true;
    }
}
