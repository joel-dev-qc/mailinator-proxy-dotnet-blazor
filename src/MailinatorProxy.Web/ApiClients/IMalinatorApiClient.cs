// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Mails;
using MailinatorProxy.Shared.Enums;

namespace MailinatorProxy.Web.ApiClients;

internal interface IMalinatorApiClient
{
    Task<GetMailAttachmentsQueryResponse> GetMailAttachmentsAsync(string domain, string messageId);
    Task<GetMailAttachmentByIdQueryResponse> GetMailAttachmentByIdAsync(string domain, string inbox, string messageId, string attachmentId);
    Task<GetMailByIdQueryResponse> GetMailByIdAsync(string domain, string inbox, string messageId);
    Task<GetMailInboxQueryResponse> GetMailInboxAsync(string domain, string inbox, bool decodeSubject = false, SortingDirection? sort = null, int? limit = null, int? skip = null);
}
