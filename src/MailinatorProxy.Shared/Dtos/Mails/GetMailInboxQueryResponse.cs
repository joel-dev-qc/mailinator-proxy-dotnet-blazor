// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Shared.Dtos.Mails;

public class GetMailInboxQueryResponse
{
    public string Domain { get; set; }

    public string To { get; set; }
    public List<MessageDto> Messages { get; set; } = [];
}
