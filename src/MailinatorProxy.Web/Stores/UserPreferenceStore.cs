// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;
using MailinatorProxy.Web.Models;
using MailinatorProxy.Web.Stores.Interfaces;

namespace MailinatorProxy.Web.Stores;

public class UserPreferenceStore(ILocalStorageService localStorageService) : IUserPreferenceStore
{
    private const string Key = "userPreferences";

    public async Task<UserPreference> LoadAsync(CancellationToken ct = default)
    {
        var userPreference = await localStorageService.GetItemAsync<UserPreference>(Key, ct);
        return userPreference ?? new UserPreference();
    }

    public async Task SaveAsync(UserPreference preferences, CancellationToken ct = default)
    {
        await localStorageService.SetItemAsync(Key, preferences, ct);
    }
}
