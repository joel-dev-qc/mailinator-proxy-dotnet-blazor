// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailAttachmentById;

public static class GetMailAttachmentByIdQueryEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/{Domain}/{Inbox}/{MessageId}/attachments/{AttachmentId}", async Task<Ok<GetMailAttachmentByIdQueryResponse>> (
                ISender mediator,
                [AsParameters] GetMailAttachmentByIdQuery request,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(request, cancellationToken);
                return TypedResults.Ok(response);
            })
            .Produces<GetMailAttachmentByIdQueryResponse>()
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .WithMetadata()
            .WithSummary("Get Mail Attachment By Id")
            .WithName("GetMailAttachmentById")
            .WithDescription("This endpoint retrieves a list of attachments for a message. Note attachments are expected to be in Email format.");
    }
}
