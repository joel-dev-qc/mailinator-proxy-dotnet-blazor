// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;
using MailinatorProxy.API.Common.ApiClients.Mailinator;
using MailinatorProxy.API.Common.Behaviors;

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
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<IApplicationMarker>();
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

    }

    public static void AddFluentValidation(this IServiceCollection services)
    {
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(includeInternalTypes: true);
    }
}
