// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;

namespace MailinatorProxy.Web.States;

internal class MailToFavoriteState(ILocalStorageService localStorage)
{
    private readonly Dictionary<string, HashSet<string>> _favoritesByDomain = new();

    public event Action<string, string>? OnFavoriteChanged;

    public event Action<string>? OnChanged;

    public async Task InitializeAsync(string domain)
    {
        if (_favoritesByDomain.ContainsKey(domain)) return;

        var favorites = await localStorage.GetItemAsync<HashSet<string>>(GetKey(domain)) ?? [];

        _favoritesByDomain[domain] = favorites;
    }

    public IReadOnlyCollection<string> GetAllFavorites(string domain)
    {
        Console.WriteLine("Fetching favorites for domain: " + domain);
        if (!_favoritesByDomain.ContainsKey(domain))
        {
            Console.WriteLine("No favorites found for domain: " + domain);
            return [];
        }
        return _favoritesByDomain.TryGetValue(domain, out var set) ? set : [];
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

        if (!set.Add(id))
            set.Remove(id);

        await localStorage.SetItemAsync(GetKey(domain), set);

        OnFavoriteChanged?.Invoke(domain, id);
        OnChanged?.Invoke(domain);
    }

    private static string GetKey(string domain) => $"favorites:{domain}";
}
