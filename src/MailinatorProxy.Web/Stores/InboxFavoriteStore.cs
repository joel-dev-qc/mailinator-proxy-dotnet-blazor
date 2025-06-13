// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;
using MailinatorProxy.Web.Stores.Interfaces;

namespace MailinatorProxy.Web.Stores;

public class InboxFavoriteStore(ILocalStorageService localStorageService) : IInboxFavoriteStore
{
    private static string GetKey(string domain) => $"favorites:{domain}";

    public async Task<HashSet<string>> LoadFavoritesAsync(string domain, CancellationToken ct = default)
    {
        return await localStorageService.GetItemAsync<HashSet<string>>(GetKey(domain), ct) ?? [];
    }

    public async Task SaveFavoritesAsync(string domain, HashSet<string> ids, CancellationToken ct = default)
    {
        await localStorageService.SetItemAsync(GetKey(domain), ids, ct);
    }
}
