// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MailinatorProxy.Shared.Dtos.Domains;
using MediatR;

namespace MailinatorProxy.API.Features.Domains.Queries.GetAllDomains;

internal class GetAllDomainsQueryHandler(IMailinatorClient mailinatorClient) : IRequestHandler<GetAllDomainsQuery, GetAllDomainsQueryResponse>
{
    public async Task<GetAllDomainsQueryResponse> Handle(GetAllDomainsQuery request, CancellationToken cancellationToken)
    {
        var domains = await mailinatorClient.DomainsClient.GetAllDomainsAsync();
        return new GetAllDomainsQueryResponse()
        {
            Domains = domains.Domains.Select(x => x.MapToGetAllDomainsQueryResponse()).ToList()
        };
    }
}
