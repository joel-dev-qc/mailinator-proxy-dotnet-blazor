// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

public static class GetTeamStatsQueryEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("stats", async Task<Ok<GetTeamStatsQueryResponse>> (
                ISender mediator,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(new GetTeamStatsQuery(), cancellationToken);
                return TypedResults.Ok(response);
            })
            .WithName("GetTeamStats")
            .WithSummary("Get team stats")
            .WithDescription(
                "This endpoint retrieves the statistics for the team, including team stats and plan details.")
            .Produces<GetTeamStatsQueryResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
