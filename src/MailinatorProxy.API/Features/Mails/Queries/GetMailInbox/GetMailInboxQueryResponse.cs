// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Common.Dtos;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

public class GetMailInboxQueryResponse
{
    public string Domain { get; set; }
    public string To { get; set; }
    public List<MessageDto> Messages { get; set; } = [];
}
