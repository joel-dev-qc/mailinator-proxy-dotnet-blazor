// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

internal static class GetMailInboxQueryEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder group)
    {
        group.MapGet("/{Domain}/{Inbox}", async Task<Ok<GetMailInboxQueryResponse>> (
                ISender mediator,
                [AsParameters] GetMailInboxQuery query,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(query, cancellationToken);
                return TypedResults.Ok(response);
            })
            .Produces<GetMailInboxQueryResponse>()
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .WithName("GetMailInbox")
            .WithDescription("This endpoint retrieves a list of messages summaries. You can retrieve a list by inbox, inboxes, or entire domain.");
    }
}
