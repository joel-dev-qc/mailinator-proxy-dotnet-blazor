// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Web.Models;
using MudBlazor;

namespace MailinatorProxy.Web.Services;

public interface ILayoutService
{
    void SetDarkMode(bool value);
    DarkLightMode CurrentDarkLightMode { get; }
    bool IsDarkMode { get; }
    bool ObserveSystemThemeChange { get; }
    MudTheme CurrentTheme { get; }
    Task ApplyUserPreferences(bool isDarkModeDefaultTheme);
    Task OnSystemPreferenceChanged(bool newValue);
    event EventHandler MajorUpdateOccurred;
    Task CycleDarkLightModeAsync();
    void SetBaseTheme(MudTheme theme);
}
