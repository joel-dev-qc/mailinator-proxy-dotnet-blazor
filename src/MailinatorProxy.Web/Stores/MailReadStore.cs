// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;
using MailinatorProxy.Web.Stores.Interfaces;

namespace MailinatorProxy.Web.Stores;

public class MailReadStore(ILocalStorageService localStorageService) : IMailReadStore
{
    private const string KeyPrefix = "read-messages:";
    private static readonly TimeSpan s_expiration = TimeSpan.FromDays(7);

    public async Task MarkAsReadAsync(string domain, string messageId, CancellationToken ct = default)
    {
        string key = GetKey(domain);
        var dict = await localStorageService.GetItemAsync<Dictionary<string, DateTime>>(key, ct) ?? new();

        dict[messageId] = DateTime.UtcNow;

        // Cleanup here
        var now = DateTime.UtcNow;
        var pruned = dict
            .Where(kvp => now - kvp.Value < s_expiration)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        await localStorageService.SetItemAsync(key, pruned);
    }

    public async Task<bool> IsReadAsync(string domain, string messageId, CancellationToken ct = default)
    {
        string key = GetKey(domain);
        var dict = await localStorageService.GetItemAsync<Dictionary<string, DateTime>>(key, ct) ?? new Dictionary<string, DateTime>();
        return dict.ContainsKey(messageId);
    }

    public async Task RemoveAsync(string domain, string messageId, CancellationToken ct = default)
    {
        string key = GetKey(domain);
        var dict = await localStorageService.GetItemAsync<Dictionary<string, DateTime>>(key, ct);
        if (dict is null || !dict.Remove(messageId))
            return;

        await localStorageService.SetItemAsync(key, dict);
    }

    private static string GetKey(string domain) => $"{KeyPrefix}{domain}";
}
