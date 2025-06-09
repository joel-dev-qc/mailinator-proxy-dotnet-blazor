// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

public class TeamStatDto
{
    public DateTime Date { get; set; }
    public SentDto Sent { get; set; }
    public RetrievedDto Retrieved { get; set; }
}
