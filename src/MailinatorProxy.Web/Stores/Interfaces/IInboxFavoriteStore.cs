// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.Stores.Interfaces;

public interface IInboxFavoriteStore
{
    Task<HashSet<string>> LoadFavoritesAsync(string domain, CancellationToken ct = default);
    Task SaveFavoritesAsync(string domain, HashSet<string> ids, CancellationToken ct = default);
}
