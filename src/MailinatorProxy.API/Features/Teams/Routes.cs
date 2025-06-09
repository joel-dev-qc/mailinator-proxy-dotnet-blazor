// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Features.Teams.GetTeamStats;

namespace MailinatorProxy.API.Features.Teams;

internal static class Routes
{
    internal static void RegisterTeamRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/teams").WithTags("Teams");

        GetTeamStatsQueryEndpoint.RegisterRoute(group);
    }
}
