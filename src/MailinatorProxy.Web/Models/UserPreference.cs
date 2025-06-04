// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.Models;

public class UserPreference
{
    /// <summary>
    /// The current dark light mode that is used
    /// </summary>
    public DarkLightMode DarkLightTheme { get; set; }
}
