// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

public static class GetMailInboxQueryEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder group)
    {
        group.MapGet("/{Inbox}", async (
                ISender mediator,
                [AsParameters] GetMailInboxQuery query) =>
            {
                var response = await mediator.Send(query);
                return response is not null ? Results.Ok(response) : Results.NotFound();
            })
            .WithName("GetMailInbox")
            .Produces<FetchInboxResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }
}
