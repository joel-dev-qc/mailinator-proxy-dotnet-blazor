// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailById;

public static class GetMailByIdQueryEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder group)
    {
        group.MapGet("/{Domain}/{Inbox}/{MessageId}", async Task<Ok<GetMailByIdQueryResponse>> (
                ISender mediator,
                [AsParameters] GetMailByIdQuery query,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(query, cancellationToken);
                return TypedResults.Ok(response);
            })
            .Produces<GetMailByIdQueryResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .WithMetadata()
            .WithSummary("Get Mail By Id")
            .WithName("GetMailById")
            .WithDescription("This endpoint retrieves a specific message by id.");
    }
}
