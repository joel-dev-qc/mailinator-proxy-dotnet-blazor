// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

public class GetTeamStatsQueryResponse
{
    public List<TeamStatDto> TeamStats { get; set; }
    public TeamPlanDto TeamPlan { get; set; }
}
