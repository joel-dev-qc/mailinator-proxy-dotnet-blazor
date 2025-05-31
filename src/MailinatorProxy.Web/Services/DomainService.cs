// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Blazored.LocalStorage;
using MailinatorProxy.Shared.Dtos.Domains;
using MailinatorProxy.Web.ApiClients;

namespace MailinatorProxy.Web.Services;

internal class DomainService(IMalinatorApiClient apiClient, ILocalStorageService localStorage)
    : IDomainService
{
    private const string CacheKey = "domains";
    private const string CacheTimestampKey = "domains_timestamp";
    private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(30);
    private List<DomainDto>? _domains;

    public async Task<List<DomainDto>> GetDomainsAsync()
    {
        if (_domains is not null)
            return _domains;

        var timestamp = await localStorage.GetItemAsync<DateTime?>(CacheTimestampKey);
        if (timestamp is not null && DateTime.UtcNow - timestamp < _cacheDuration)
        {
            _domains = await localStorage.GetItemAsync<List<DomainDto>>(CacheKey);
            if (_domains is not null)
                return _domains;
        }

        var response = await apiClient.GetAllDomainsAsync();
        _domains = response.Domains;

        await localStorage.SetItemAsync(CacheKey, _domains);
        await localStorage.SetItemAsync(CacheTimestampKey, DateTime.UtcNow);

        return _domains!;
    }

    public async Task<bool> IsValidAsync(string domain)
    {
        var list = await GetDomainsAsync();
        return list.Any(d => d.Name.Equals(domain, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<DomainDto?> GetFirstAsync()
    {
        var list = await GetDomainsAsync();
        return list.FirstOrDefault();
    }

    public async Task ClearCacheAsync()
    {
        _domains = null;
        await localStorage.RemoveItemAsync(CacheKey);
        await localStorage.RemoveItemAsync(CacheTimestampKey);
    }
}
