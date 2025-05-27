// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Net.Http.Json;
using MailinatorProxy.Shared.Dtos.Mails;
using MailinatorProxy.Shared.Enums;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace MailinatorProxy.Web.ApiClients;

public class MailinatorApiClient(HttpClient httpClient) : IMalinatorApiClient
{
    public async Task<GetMailAttachmentsQueryResponse> GetMailAttachmentsAsync(string domain, string messageId)
    {
        return await httpClient.GetFromJsonAsync<GetMailAttachmentsQueryResponse>($"/mails/{domain}/{messageId}/attachments");
    }

    public async Task<GetMailAttachmentByIdQueryResponse> GetMailAttachmentByIdAsync(string domain, string inbox, string messageId, string attachmentId)
    {
        return await httpClient.GetFromJsonAsync<GetMailAttachmentByIdQueryResponse>($"/mails/{domain}/{inbox}/{messageId}/attachments/{attachmentId}");
    }

    public async Task<GetMailByIdQueryResponse> GetMailByIdAsync(string domain, string inbox, string messageId)
    {
        return await httpClient.GetFromJsonAsync<GetMailByIdQueryResponse>($"/mails/{domain}/{inbox}/{messageId}");
    }

    public async Task<GetMailInboxQueryResponse> GetMailInboxAsync(string domain, string inbox, bool decodeSubject = false, SortingDirection? sort = null, int? limit = null, int? skip = null)
    {
        string url = QueryHelpers.AddQueryString($"/mails/{domain}/{inbox}",
            new List<KeyValuePair<string, StringValues>>()
            {
                new("decodeSubject", decodeSubject.ToString()),
                new("sort", sort?.ToString()),
                new("limit", limit?.ToString()),
                new("skip", skip?.ToString())
            });
        return await httpClient.GetFromJsonAsync<GetMailInboxQueryResponse>(url);
    }
}
