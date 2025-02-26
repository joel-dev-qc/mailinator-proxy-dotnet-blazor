// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Messages.Entities;
using Riok.Mapperly.Abstractions;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;

[Mapper]
internal static partial class GetMailAttachmentsQueryMapper
{
    public static partial AttachmentDto MapAttachmentDto(this Attachment attachment);
}
