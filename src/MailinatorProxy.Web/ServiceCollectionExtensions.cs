// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Web.States;
using MailinatorProxy.Web.Stores;
using MailinatorProxy.Web.Stores.Interfaces;

namespace MailinatorProxy.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStores(this IServiceCollection services)
    {
        services.AddScoped<IInboxFavoriteStore, InboxFavoriteStore>();
        services.AddScoped<IMailReadStore, MailReadStore>();
        services.AddScoped<IUserPreferenceStore, UserPreferenceStore>();
        return services;
    }

    public static IServiceCollection AddStates(this IServiceCollection services)
    {
        services.AddScoped<DomainState>();
        services.AddScoped<InboxFilterState>();
        services.AddScoped<InboxFavoriteState>();
        services.AddScoped<MailReadState>();
        return services;
    }
}
