using MailinatorProxy.Shared.Dtos.Mails;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MailinatorProxy.API.Features.Mails.Commands.DeleteMailAttachmentById;

internal static class DeleteMailByIdCommandEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{Domain}/{Inbox}/{MessageId}", async Task<Ok<DeleteMailByIdCommandResponse>> (
                ISender mediator,
                [AsParameters] DeleteMailByIdCommand request,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(request, cancellationToken);
                return TypedResults.Ok(response);
            })
            .Produces<DeleteMailByIdCommandResponse>()
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .WithMetadata()
            .WithSummary("Delete Mail Attachment By Id")
            .WithName("DeleteMailAttachmentById")
            .WithDescription("This endpoint deletes a specific messages");
    }
}
