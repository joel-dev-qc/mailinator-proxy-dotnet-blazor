// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.Stores.Interfaces;

public interface IMailReadStore
{
    Task<bool> IsReadAsync(string domain, string messageId, CancellationToken ct = default);
    Task MarkAsReadAsync(string domain, string messageId, CancellationToken ct = default);
    Task RemoveAsync(string domain, string messageId, CancellationToken ct = default);
}
