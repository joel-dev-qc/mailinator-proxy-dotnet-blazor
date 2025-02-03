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
    ): IRequestHandler<GetMailInboxQuery, FetchInboxResponse>
{
    public Task<FetchInboxResponse> Handle(GetMailInboxQuery request, CancellationToken cancellationToken)
    {
        return mailinatorClient.MessagesClient.FetchInboxAsync(request.MapFetchInboxRequest());
    }
}
