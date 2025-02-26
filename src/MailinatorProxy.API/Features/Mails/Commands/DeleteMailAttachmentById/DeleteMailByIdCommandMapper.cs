using mailinator_csharp_client.Models.Responses;
using Riok.Mapperly.Abstractions;

namespace MailinatorProxy.API.Features.Mails.Commands.DeleteMailAttachmentById;

[Mapper]
internal static partial class DeleteMailByIdCommandMapper
{
    public static partial DeleteMailByIdCommandResponse ToDeleteMailByIdCommandResponse(this DeleteMessageResponse deleteMessageResponse);
}
