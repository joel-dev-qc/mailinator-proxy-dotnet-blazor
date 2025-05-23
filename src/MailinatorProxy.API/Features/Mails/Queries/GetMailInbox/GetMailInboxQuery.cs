// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MailinatorProxy.API.Common.Enums;
using MailinatorProxy.Shared.Dtos.Mails;
using MediatR;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

public class GetMailInboxQuery : IRequest<GetMailInboxQueryResponse>
{

    [Description("""
                 ## Description
                 The domain from which to fetch email message summaries.
                 ## Accepted values:
                 - `public` - Fetch messages from the Public Mailinator System.
                 - `private` - Fetch messages from all your Private Domains.
                 - `[your_private_domain.com]` - Fetch messages from a specific Private Domain.
                 - Defaults to `private`.
                 """)]
    [Required]
    public string Domain { get; set; } = "private";

    [Description("""
                 ## Description
                 The inbox from which to fetch email message summaries.
                 ## Accepted values:
                 - `null` or `*` - Fetch all messages for an entire domain.
                 - `[inbox_name]` - Fetch messages for a specific inbox.
                 - `[inbox_name*]` - Fetch messages for all inboxes matching a given prefix.
                 - Defaults to `null`.
                 """)]
    [Required]
    public string Inbox { get; set; } = "null";

    [Description("""
                 ## Description
                 Number of emails to skip in the result set.
                 - Defaults to `0` if not provided.
                 """)]
    public int? Skip { get; set; }

    [Description("""
                 ## Description
                 Number of emails to fetch from the Private Domain.
                 - Defaults to `50` if not provided.
                 """)]
    [Range(1, 100)]
    public int? Limit { get; set; } = 50;

    [Description("""
                 ## Description
                 Sort order of the results.
                 ## Available values:
                 - `SortingDirection.Ascending`
                 - `SortingDirection.Descending`
                 - Defaults to `SortingDirection.Descending`.
                 """)]
    public SortingDirection? Sort { get; set; } = SortingDirection.Descending;

    [Description("""
                 ## Description
                 Specifies whether to decode encoded email subjects.
                 - `true` to decode encoded subjects; `false` to return them as is.
                 - Defaults to `false`.
                 """)]
    public bool? DecodeSubject { get; set; }
}
