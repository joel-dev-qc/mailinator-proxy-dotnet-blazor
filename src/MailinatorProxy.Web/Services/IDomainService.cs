// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Domains;

namespace MailinatorProxy.Web.Services;

internal interface IDomainService
{
    Task<List<DomainDto>> GetDomainsAsync();
    Task<bool> IsValidAsync(string domain);
    Task<DomainDto?> GetFirstAsync();
    Task ClearCacheAsync();
}
