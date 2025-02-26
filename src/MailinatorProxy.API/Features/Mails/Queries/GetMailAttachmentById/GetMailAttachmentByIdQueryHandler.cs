using mailinator_csharp_client.Models.Messages.Requests;
using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachmentById
{
    internal class GetMailAttachmentByIdQueryHandler(IMailinatorClient mailinatorClient)
        : IRequestHandler<GetMailAttachmentByIdQuery, GetMailAttachmentByIdQueryResponse>
    {
        public async Task<GetMailAttachmentByIdQueryResponse> Handle(GetMailAttachmentByIdQuery request, CancellationToken cancellationToken)
        {
            var getMailAttachmentByIdResponse = await mailinatorClient.MessagesClient.FetchInboxMessageAttachmentAsync(new FetchInboxMessageAttachmentRequest()
            {
                Domain = request.Domain,
                MessageId = request.MessageId,
                AttachmentId = request.AttachmentId,
                Inbox = request.Inbox
            });

            return getMailAttachmentByIdResponse.MapToGetMailAttachmentByIdQueryResponse();
        }
    }
}
