// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;

namespace MailinatorProxy.Web.Services;

internal class MailReadStateService(ILocalStorageService localStorage) : IMailReadStateService
{
    private const string KeyPrefix = "read-messages:";
    private static readonly TimeSpan s_expiration = TimeSpan.FromDays(7);

    public async Task MarkAsReadAsync(string domain, string messageId)
    {
        string key = GetKey(domain);
        var dict = await localStorage.GetItemAsync<Dictionary<string, DateTime>>(key) ?? new();

        dict[messageId] = DateTime.UtcNow;

        // Cleanup here
        var now = DateTime.UtcNow;
        var pruned = dict
            .Where(kvp => now - kvp.Value < s_expiration)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        await localStorage.SetItemAsync(key, pruned);
    }

    public async Task<bool> IsReadAsync(string domain, string messageId)
    {
        string key = GetKey(domain);
        var dict = await localStorage.GetItemAsync<Dictionary<string, DateTime>>(key) ?? new();
        return dict.ContainsKey(messageId);
    }

    public async Task RemoveAsync(string domain, string messageId)
    {
        string key = GetKey(domain);
        var dict = await localStorage.GetItemAsync<Dictionary<string, DateTime>>(key);
        if (dict is null || !dict.Remove(messageId))
            return;

        await localStorage.SetItemAsync(key, dict);
    }

    private static string GetKey(string domain) => $"{KeyPrefix}{domain}";
}

