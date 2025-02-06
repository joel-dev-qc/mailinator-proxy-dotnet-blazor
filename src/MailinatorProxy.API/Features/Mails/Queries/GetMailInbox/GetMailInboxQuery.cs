// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using mailinator_csharp_client.Models.Responses;
using MailinatorProxy.API.Common.Enums;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

internal class GetMailInboxQuery : IRequest<GetMailInboxQueryResponse>
{
    public string? Domain { get; set; } = "private";

    /// <summary>
    /// Test of description
    /// </summary>
    public string Inbox { get; set; } = "null";

    public int? Skip { get; set; }

    public int? Limit { get; set; } = 50;

    public SortingDirection? Sort { get; set; } = SortingDirection.Descending;

    public bool? DecodeSubject { get; set; }
}
