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
        group.MapGet("/inbox", async Task<Results<Ok<GetMailInboxQueryResponse>, NoContent>> (
                ISender mediator,
                [AsParameters] GetMailInboxQuery query,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(query, cancellationToken);
                return response is not null
                    ? TypedResults.Ok<GetMailInboxQueryResponse>(response)
                    : TypedResults.NoContent();
            })
            .Produces<GetMailInboxQueryResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi()
            .WithName("GetMailInbox")
            .WithDescription("Fetches the inbox of the specified mailinator inbox.");
    }
}
