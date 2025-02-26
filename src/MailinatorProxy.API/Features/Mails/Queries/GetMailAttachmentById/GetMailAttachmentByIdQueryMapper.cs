// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Responses;
using Riok.Mapperly.Abstractions;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachmentById;

[Mapper]
internal static partial class GetMailAttachmentByIdQueryMapper
{
    public static partial GetMailAttachmentByIdQueryResponse MapToGetMailAttachmentByIdQueryResponse(this FetchInboxMessageAttachmentResponse fetchAttachmentResponse);
}
