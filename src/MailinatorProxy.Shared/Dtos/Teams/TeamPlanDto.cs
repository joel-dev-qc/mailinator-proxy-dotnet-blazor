// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

public class TeamPlanDto
{
    public int StorageMb { get; set; }
    public int NumberOfPrivateDomains { get; set; }
    public int EmailReadsPerDay { get; set; }
    public int TeamAccounts { get; set; }
}
