// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.Services;

public interface IMailReadStateService
{
    Task MarkAsReadAsync(string domain, string messageId);
    Task<bool> IsReadAsync(string domain, string messageId);
    Task RemoveAsync(string domain, string messageId);
}
