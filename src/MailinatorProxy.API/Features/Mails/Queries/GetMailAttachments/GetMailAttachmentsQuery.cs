using MediatR;
using MailinatorProxy.Shared.Dtos.Mails;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;
internal class GetMailAttachmentsQuery : IRequest<GetMailAttachmentsQueryResponse>
{
    public string Domain { get; set; }
    public string MessageId { get; set; }
}
