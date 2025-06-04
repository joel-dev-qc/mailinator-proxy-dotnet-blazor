// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;
using MailinatorProxy.Web.Models;

namespace MailinatorProxy.Web.Services;

internal class UserPreferencesService(ILocalStorageService localStorage) : IUserPreferencesService
{
    private const string Key = "userPreferences";

    public async Task SaveUserPreferences(UserPreference userPreferences)
    {
        await localStorage.SetItemAsync(Key, userPreferences);
    }

    public async Task<UserPreference> LoadUserPreferences()
    {
        var userPreference = await localStorage.GetItemAsync<UserPreference>(Key);
        return userPreference ?? new UserPreference();
    }
}
