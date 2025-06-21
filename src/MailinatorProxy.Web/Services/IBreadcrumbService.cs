// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MudBlazor;

namespace MailinatorProxy.Web.Services;

public interface IBreadcrumbService
{
    List<BreadcrumbItem> GetInboxBreadcrumbs(string domain, string? mailId = null);
    List<BreadcrumbItem> GetHomeBreadcrumbs();
}
