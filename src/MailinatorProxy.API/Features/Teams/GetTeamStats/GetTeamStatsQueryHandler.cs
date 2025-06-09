// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MediatR;

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

internal class GetTeamStatsQueryHandler(IMailinatorClient mailinatorClient) : IRequestHandler<GetTeamStatsQuery, GetTeamStatsQueryResponse>
{
    public async Task<GetTeamStatsQueryResponse> Handle(GetTeamStatsQuery request, CancellationToken cancellationToken)
    {
        var teamStatsResponse = mailinatorClient.StatsClient.GetTeamStatsAsync();
        var teamResponse = mailinatorClient.StatsClient.GetTeamAsync();

        await Task.WhenAll(teamStatsResponse, teamResponse);

        return new GetTeamStatsQueryResponse
        {
            TeamStats = (await teamStatsResponse).Stats.Select(x => x.MapToTeamStatDto()).ToList(),
            TeamPlan = (await teamResponse).PlanData.MapToTeamPlanDto()
        };
    }
}
