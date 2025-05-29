// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.JSInterop;
using MudBlazor;

namespace MailinatorProxy.Web.Services;

public class ClipboardService(IJSRuntime jsRuntime, ISnackbar snackbar) : IClipboardService
{
    public async Task CopyToClipboardAsync(string text, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(text))
            return;

        await jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", cancellationToken, text);
        snackbar.Add("Content copied to clipboard", Severity.Info, config =>
        {
            config.HideTransitionDuration = 500;
        });
    }
}
