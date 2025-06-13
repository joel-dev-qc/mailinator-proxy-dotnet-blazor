// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Web.Models;

namespace MailinatorProxy.Web.Stores.Interfaces;

public interface IUserPreferenceStore
{
    Task<UserPreference> LoadAsync(CancellationToken ct = default);
    Task SaveAsync(UserPreference preferences, CancellationToken ct = default);
}
