// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Mails;

namespace MailinatorProxy.Web.Services;

public interface IInboxDataService
{
    Task<(List<MessageDto> Messages, bool HasMoreData)> LoadInboxDataAsync(string domain, string inbox, int offset, int pageSize, bool forceReload = false);
    Task<List<MessageDto>> CheckForNewMessagesAsync(string domain, string inbox, int limit);
    Task<bool> DeleteMessageAsync(string domain, string inbox, string messageId);
    Task<MessageDto?> GetMessageAsync(string domain, string inbox, string messageId);
    bool IsMessageUnread(string domain, string messageId);
    string GetCurrentInbox(string domain);
    void SetCurrentInbox(string domain, string inbox);
    void ClearState(string domain);
    List<MessageDto> GetCurrentMessages(string domain);
    bool HasMoreData(string domain);
    Task SyncReadStatesAsync(string domain);
}
