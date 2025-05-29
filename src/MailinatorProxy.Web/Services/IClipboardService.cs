// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.Services;

public interface IClipboardService
{
    Task CopyToClipboardAsync(string text, CancellationToken cancellationToken = default);
}
