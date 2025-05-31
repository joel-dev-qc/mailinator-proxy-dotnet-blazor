// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Shared.Dtos.Domains;

public class GetAllDomainsQueryResponse
{
    public List<DomainDto> Domains { get; set; } = [];
}
