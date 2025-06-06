// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MailinatorProxy.Shared.Dtos.Mails;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

internal class GetMailInboxQueryHandler(
    IMailinatorClient mailinatorClient,
    ILogger<GetMailInboxQueryHandler> logger
    ): IRequestHandler<GetMailInboxQuery, GetMailInboxQueryResponse>
{
    public async Task<GetMailInboxQueryResponse> Handle(GetMailInboxQuery request, CancellationToken cancellationToken)
    {
        var fetchInboxRequest = request.MapFetchInboxRequest();
        var response = await mailinatorClient.MessagesClient.FetchInboxAsync(fetchInboxRequest);
        return response.MapGetMailInboxQueryResponse();
    }
}
