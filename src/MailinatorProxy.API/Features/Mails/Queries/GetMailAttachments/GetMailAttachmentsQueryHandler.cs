using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MediatR;
using mailinator_csharp_client.Models.Messages.Requests;
using MailinatorProxy.Shared.Dtos.Mails;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;

internal class GetMailAttachmentsQueryHandler(IMailinatorClient mailinatorClient) : IRequestHandler<GetMailAttachmentsQuery, GetMailAttachmentsQueryResponse>
{

    public async Task<GetMailAttachmentsQueryResponse> Handle(GetMailAttachmentsQuery request, CancellationToken cancellationToken)
    {
        // Logic to get mail attachments using _mailService
        var attachments = await mailinatorClient.MessagesClient.FetchMessageAttachmentsAsync(new FetchMessageAttachmentsRequest()
        {
            Domain = request.Domain,
            MessageId = request.MessageId,
        });
        return new GetMailAttachmentsQueryResponse
        {
            Attachments = attachments.Attachments.Select(x => x.MapAttachmentDto()).ToList(),
        };
    }
}
