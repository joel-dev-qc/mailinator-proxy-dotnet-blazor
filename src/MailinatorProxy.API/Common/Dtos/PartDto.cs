// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.API.Common.Dtos;

public class PartDto
{
    public Dictionary<string, object> Headers { get; set; }
    public string Body { get; set; }
}
