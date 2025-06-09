// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Stats.Entities;
using Riok.Mapperly.Abstractions;

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

[Mapper]
internal static partial class GetTeamStatsQueryMapper
{
    public static partial TeamStatDto MapToTeamStatDto(this Stat teamStat);
    public static partial TeamPlanDto MapToTeamPlanDto(this PlanData teamStat);

    private static DateTime MapToDateTime(string date)
    {
        return DateTime.ParseExact(date, "yyyyMMdd",null);
    }
}
