// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Common.ApiClients.Mailinator;

namespace MailinatorProxy.API;

internal static class ServiceCollectionExtensions
{
    public static void AddMailinatorApiClientProxy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMailinatorClient, MailinatorClientWrapper>(provider =>
            new MailinatorClientWrapper(configuration.GetValue<string>("Mailinator:ApiKey")));
    }

    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationMarker>());
    }
}
