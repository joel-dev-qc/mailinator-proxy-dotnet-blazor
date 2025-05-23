using MailinatorProxy.Shared.Dtos.Mails;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Commands.DeleteMailAttachmentById;

internal class DeleteMailByIdCommand : IRequest<DeleteMailByIdCommandResponse>
{
    public string Domain { get; set; }
    public string Inbox { get; set; }
    public string MessageId { get; set; }
}
