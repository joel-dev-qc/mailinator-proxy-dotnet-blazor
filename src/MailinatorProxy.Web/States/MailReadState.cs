// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Web.Stores.Interfaces;

namespace MailinatorProxy.Web.States;

public class MailReadState(IMailReadStore store)
{
    private readonly Dictionary<string, HashSet<string>> _cache = new();

    public event Action<string, string>? OnChanged;

    public async Task InitializeAsync(string domain)
    {
        if (_cache.ContainsKey(domain)) return;

        _cache[domain] = new HashSet<string>();

        // On ne peut pas charger la liste complète des messages lus avec le `store` actuel,
        // donc on laisse le cache se remplir dynamiquement au fur et à mesure des appels à IsReadAsync/MarkAsReadAsync.
    }

    public async Task<bool> IsReadAsync(string domain, string messageId)
    {
        if (_cache.TryGetValue(domain, out var set) && set.Contains(messageId))
            return true;

        bool isRead = await store.IsReadAsync(domain, messageId);
        if (isRead)
        {
            if (!_cache.ContainsKey(domain))
                _cache[domain] = new HashSet<string>();

            _cache[domain].Add(messageId);
        }

        return isRead;
    }

    public async Task MarkAsReadAsync(string domain, string messageId)
    {
        await store.MarkAsReadAsync(domain, messageId);

        if (!_cache.ContainsKey(domain))
            _cache[domain] = new HashSet<string>();

        if (_cache[domain].Add(messageId))
            OnChanged?.Invoke(domain, messageId);
    }

    public async Task RemoveAsync(string domain, string messageId)
    {
        await store.RemoveAsync(domain, messageId);

        if (_cache.TryGetValue(domain, out var set) && set.Remove(messageId))
            OnChanged?.Invoke(domain, messageId);
    }
}
