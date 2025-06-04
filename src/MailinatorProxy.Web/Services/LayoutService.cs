// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Web.Models;
using MudBlazor;

namespace MailinatorProxy.Web.Services;

internal class LayoutService(IUserPreferencesService userPreferencesService) : ILayoutService
{
    private UserPreference _userPreferences;
    private bool _systemPreferences;

    public void SetDarkMode(bool value)
    {
        IsDarkMode = value;
    }

    public DarkLightMode CurrentDarkLightMode { get; private set; } = DarkLightMode.System;

    public bool IsDarkMode { get; private set; }

    public bool ObserveSystemThemeChange { get; private set; }

    public MudTheme CurrentTheme { get; private set; }


    private void OnMajorUpdateOccurred() => MajorUpdateOccurred?.Invoke(this, EventArgs.Empty);

    public async Task ApplyUserPreferences(bool isDarkModeDefaultTheme)
    {
        _systemPreferences = isDarkModeDefaultTheme;

        _userPreferences = await userPreferencesService.LoadUserPreferences();

        if (_userPreferences != null)
        {
            CurrentDarkLightMode = _userPreferences.DarkLightTheme;
            IsDarkMode = CurrentDarkLightMode switch
            {
                DarkLightMode.Dark => true,
                DarkLightMode.Light => false,
                DarkLightMode.System => isDarkModeDefaultTheme,
                _ => IsDarkMode
            };
        }
        else
        {
            IsDarkMode = isDarkModeDefaultTheme;
            _userPreferences = new UserPreference { DarkLightTheme = DarkLightMode.System };
            await userPreferencesService.SaveUserPreferences(_userPreferences);
            OnMajorUpdateOccurred();
        }
    }

    public Task OnSystemPreferenceChanged(bool newValue)
    {
        _systemPreferences = newValue;

        if (CurrentDarkLightMode == DarkLightMode.System)
        {
            IsDarkMode = newValue;
            OnMajorUpdateOccurred();
        }

        return Task.CompletedTask;
    }

    public event EventHandler MajorUpdateOccurred;

    public async Task CycleDarkLightModeAsync()
    {
        switch (CurrentDarkLightMode)
        {
            // Change to Light
            case DarkLightMode.System:
                CurrentDarkLightMode = DarkLightMode.Light;
                ObserveSystemThemeChange = false;
                IsDarkMode = false;
                break;
            // Change to Dark
            case DarkLightMode.Light:
                CurrentDarkLightMode = DarkLightMode.Dark;
                ObserveSystemThemeChange = false;
                IsDarkMode = true;
                break;
            // Change to System
            case DarkLightMode.Dark:
                CurrentDarkLightMode = DarkLightMode.System;
                ObserveSystemThemeChange = true;
                IsDarkMode = _systemPreferences;
                break;
        }

        _userPreferences.DarkLightTheme = CurrentDarkLightMode;
        await userPreferencesService.SaveUserPreferences(_userPreferences);
        OnMajorUpdateOccurred();
    }

    public void SetBaseTheme(MudTheme theme)
    {
        CurrentTheme = theme;
        OnMajorUpdateOccurred();
    }
}
