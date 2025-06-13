// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;
using MailinatorProxy.Web.Stores.Interfaces;

namespace MailinatorProxy.Web.States;

internal class InboxFavoriteState(IInboxFavoriteStore store)
{
    private readonly Dictionary<string, HashSet<string>> _favoritesByDomain = new();

    public event Action<string, string>? OnFavoriteChanged;
    public event Action<string>? OnChanged;

    public async Task InitializeAsync(string domain)
    {
        if (_favoritesByDomain.ContainsKey(domain)) return;

        var favorites = await store.LoadFavoritesAsync(domain);
        _favoritesByDomain[domain] = favorites;
    }

    public IReadOnlyCollection<string> GetAllFavorites(string domain)
    {
        if (!_favoritesByDomain.TryGetValue(domain, out var set))
        {
            Console.WriteLine("No favorites found for domain: " + domain);
            return [];
        }

        return set;
    }

    public bool IsFavorite(string domain, string id) =>
        _favoritesByDomain.TryGetValue(domain, out var set) && set.Contains(id);

    public async Task ToggleFavoriteAsync(string domain, string id)
    {
        if (!_favoritesByDomain.TryGetValue(domain, out var set))
        {
            set = [];
            _favoritesByDomain[domain] = set;
        }

        bool added = set.Add(id);
        if (!added)
            set.Remove(id);

        await store.SaveFavoritesAsync(domain, set);

        OnFavoriteChanged?.Invoke(domain, id);
        OnChanged?.Invoke(domain);
    }
}
