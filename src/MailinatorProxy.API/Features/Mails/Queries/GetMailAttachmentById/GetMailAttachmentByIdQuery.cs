using MailinatorProxy.Shared.Dtos.Mails;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachmentById
{
    public class GetMailAttachmentByIdQuery : IRequest<GetMailAttachmentByIdQueryResponse>
    {
        public string Domain { get; set; }
        public string Inbox { get; set; }
        public string MessageId { get; set; }
        public string AttachmentId { get; set; }
    }

}
