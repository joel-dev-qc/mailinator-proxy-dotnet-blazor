// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

public class RetrievedDto
{
    public int WebPublic { get; set; }
    public int ApiError { get; set; }
    public int WebPrivate { get; set; }
    public int ApiEmail { get; set; }
}
