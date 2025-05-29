// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Mails;

namespace MailinatorProxy.Shared.Extensions;

public static class MessageDtoExtensions
{
    public static PartDto? GetHtmlPart(this MessageDto message)
    {
        ArgumentNullException.ThrowIfNull(message);

        return message.Parts.FirstOrDefault(p =>
            p.Headers.TryGetValue("content-type", out string? type)
            && type.Contains("text/html", StringComparison.OrdinalIgnoreCase));
    }

    public static PartDto? GetTextPart(this MessageDto message)
    {
        ArgumentNullException.ThrowIfNull(message);

        return message.Parts.FirstOrDefault(p =>
            p.Headers.TryGetValue("content-type", out string? type)
            && type.Contains("text/plain", StringComparison.OrdinalIgnoreCase));
    }
}
