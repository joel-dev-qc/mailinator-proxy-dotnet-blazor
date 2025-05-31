// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Shared.Dtos.Domains;

public class DomainDto
{
    public string Id { get; set; }
    public string Description  { get; set; }
    public bool Enabled  { get; set; }
    public string Name  { get; set; }
}
