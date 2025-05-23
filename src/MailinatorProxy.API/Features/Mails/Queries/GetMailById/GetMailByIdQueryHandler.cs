// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Messages.Requests;
using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MailinatorProxy.API.Common.Mappers;
using MailinatorProxy.Shared.Dtos.Mails;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailById;

internal class GetMailByIdQueryHandler(
    IMailinatorClient mailinatorClient,
    ILogger<GetMailByIdQueryHandler> logger) : IRequestHandler<GetMailByIdQuery, GetMailByIdQueryResponse>
{
    public async Task<GetMailByIdQueryResponse> Handle(GetMailByIdQuery request, CancellationToken cancellationToken)
    {
        var fetchMessageResponse = await mailinatorClient.MessagesClient.FetchMessageAsync(new FetchMessageRequest()
        {
            Domain = request.Domain,
            MessageId = request.MessageId,
        });
        return new GetMailByIdQueryResponse() { Message = fetchMessageResponse.MapMessageDto(), };
    }
}
