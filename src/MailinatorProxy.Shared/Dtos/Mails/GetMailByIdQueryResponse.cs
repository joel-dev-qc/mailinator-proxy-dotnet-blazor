// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Shared.Dtos.Mails;

public class GetMailByIdQueryResponse
{
    public MessageDto Message { get; set; } = new MessageDto();
}
