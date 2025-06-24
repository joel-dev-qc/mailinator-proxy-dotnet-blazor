// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using MailinatorProxy.Web.Components.AutoRefresh;
using MailinatorProxy.Web.Services;
using MailinatorProxy.Web.States;
using MailinatorProxy.Web.Stores;
using MailinatorProxy.Web.Stores.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

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
        services.AddScoped<InboxListState>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBreadcrumbService, BreadcrumbService>();
        services.AddScoped<IClipboardService, ClipboardService>();
        services.AddScoped<IDomainService, DomainService>();
        services.AddScoped<ILayoutService, LayoutService>();
        services.AddScoped<IAutoRefreshService, AutoRefreshService>();
        services.AddScoped<IInboxDataService, InboxDataService>();
        // Ajoute ici d'autres services si besoin
        return services;
    }

    public async static Task SetDefaultCulture(this WebAssemblyHost host)
    {
        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
        string? result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
        CultureInfo culture;
        if (result != null)
            culture = new CultureInfo(result);
        else
            culture = new CultureInfo("fr-CA");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}
