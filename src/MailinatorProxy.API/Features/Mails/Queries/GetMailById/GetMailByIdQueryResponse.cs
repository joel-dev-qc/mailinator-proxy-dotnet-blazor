// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Common.Dtos;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailById;

public class GetMailByIdQueryResponse
{
    public MessageDto Message { get; set; } = new MessageDto();
}
