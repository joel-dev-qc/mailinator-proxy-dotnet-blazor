// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Domains;
using MediatR;

namespace MailinatorProxy.API.Features.Domains.Queries.GetAllDomains;

public record GetAllDomainsQuery() : IRequest<GetAllDomainsQueryResponse>;
