// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailById;

public class GetMailByIdQuery : IRequest<GetMailByIdQueryResponse>
{
    public string Domain { get; set; }
    public string MessageId { get; set; } = string.Empty;
}
