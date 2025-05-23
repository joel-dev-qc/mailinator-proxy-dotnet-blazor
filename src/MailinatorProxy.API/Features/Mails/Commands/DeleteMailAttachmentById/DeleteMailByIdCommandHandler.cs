using mailinator_csharp_client.Models.Messages.Requests;
using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MailinatorProxy.Shared.Dtos.Mails;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Commands.DeleteMailAttachmentById;

internal class DeleteMailByIdCommandHandler(IMailinatorClient mailinatorClient)
    : IRequestHandler<DeleteMailByIdCommand, DeleteMailByIdCommandResponse>
{
    public async Task<DeleteMailByIdCommandResponse> Handle(DeleteMailByIdCommand request, CancellationToken cancellationToken)
    {
        var deleteMessageRequest = new DeleteMessageRequest
        {
            Domain = request.Domain,
            Inbox = request.Inbox,
            MessageId = request.MessageId
        };

        var deleteMessageResponse = await mailinatorClient.MessagesClient.DeleteMessageAsync(deleteMessageRequest);

        return deleteMessageResponse.ToDeleteMailByIdCommandResponse();
    }
}
