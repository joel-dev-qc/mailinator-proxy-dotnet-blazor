// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Domains;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MailinatorProxy.API.Features.Domains.Queries.GetAllDomains;

public static class GetAllDomainsQueryEndpoint
{
    public static void RegisterRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("", async Task<Ok<GetAllDomainsQueryResponse>> (
            ISender mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(new GetAllDomainsQuery(), cancellationToken);
            return TypedResults.Ok(response);
        }).Produces<GetAllDomainsQueryResponse>()
        .WithMetadata()
        .WithSummary("Get all Domains")
        .WithName("GetAllDomains")
        .WithDescription("This endpoint retrieves a list of all domains available in the Mailinator tenant.");
    }
}
