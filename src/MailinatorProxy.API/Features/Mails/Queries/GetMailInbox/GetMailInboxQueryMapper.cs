// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Models.Messages.Requests;
using MailinatorProxy.API.Common.Mappers;
using Riok.Mapperly.Abstractions;

namespace MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;

[Mapper]
[UseStaticMapper(typeof(CommonMappers))]
internal static partial class GetMailInboxQueryMapper
{
    public static partial FetchInboxRequest MapFetchInboxRequest(this GetMailInboxQuery query);
}
