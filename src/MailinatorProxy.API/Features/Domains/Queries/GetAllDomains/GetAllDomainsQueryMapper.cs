// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Riok.Mapperly.Abstractions;
using mailinator_csharp_client.Models.Domains.Entities;
using MailinatorProxy.Shared.Dtos.Domains;

namespace MailinatorProxy.API.Features.Domains.Queries.GetAllDomains;

[Mapper]
internal static partial class GetAllDomainsQueryMapper
{
    [MapperIgnoreSource(nameof(Domain.Rules))]
    public static partial DomainDto MapToGetAllDomainsQueryResponse(this Domain domain);
}
