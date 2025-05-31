// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Features.Domains.Queries.GetAllDomains;

namespace MailinatorProxy.API.Features.Domains;

public static class Routes
{
    public static void RegisterDomainsRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/domains")
            .WithTags("Domains");

        GetAllDomainsQueryEndpoint.RegisterRoute(group);
    }
}
