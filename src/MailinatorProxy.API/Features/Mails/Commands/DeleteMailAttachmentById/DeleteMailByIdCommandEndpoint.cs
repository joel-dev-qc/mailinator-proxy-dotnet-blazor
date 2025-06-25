using Carter;
using MailinatorProxy.API.Common.Constants;
using MailinatorProxy.Shared.Dtos.Mails;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MailinatorProxy.API.Features.Mails.Commands.DeleteMailAttachmentById;

internal class DeleteMailByIdCommandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/mails/{Domain}/{Inbox}/{MessageId}", async Task<Ok<DeleteMailByIdCommandResponse>> (
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
            .WithTags(ApiTags.Mails)
            .WithDescription("This endpoint deletes a specific messages");
    }
}
