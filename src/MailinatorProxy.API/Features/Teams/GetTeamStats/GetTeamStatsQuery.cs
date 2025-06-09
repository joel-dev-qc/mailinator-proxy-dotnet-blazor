// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;

namespace MailinatorProxy.API.Features.Teams.GetTeamStats;

public record GetTeamStatsQuery() : IRequest<GetTeamStatsQueryResponse>;
