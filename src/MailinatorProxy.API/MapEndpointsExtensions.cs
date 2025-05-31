// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Features.Domains;
using MailinatorProxy.API.Features.Mails;

namespace MailinatorProxy.API;

internal static class MapEndpointsExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.RegisterMailsRoutes();
        app.RegisterDomainsRoutes();
    }
}
