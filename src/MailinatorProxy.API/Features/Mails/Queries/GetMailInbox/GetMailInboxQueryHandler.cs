// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Messages.Requests;
using mailinator_csharp_client.Models.Responses;
using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

internal class GetMailInboxQueryHandler(
    IMailinatorClient mailinatorClient,
    ILogger<GetMailInboxQueryHandler> logger
    ): IRequestHandler<GetMailInboxQuery, GetMailInboxQueryResponse>
{
    public async Task<GetMailInboxQueryResponse> Handle(GetMailInboxQuery request, CancellationToken cancellationToken)
    {
        var response = await mailinatorClient.MessagesClient.FetchInboxAsync(request.MapFetchInboxRequest());
        return response.MapGetMailInboxQueryResponse();
    }
}
