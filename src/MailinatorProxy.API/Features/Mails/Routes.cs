// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.API.Features.Mails.Queries.GetMailAttachments;
using MailinatorProxy.API.Features.Mails.Queries.GetMailById;
using MailinatorProxy.API.Features.Mails.Queries.GetMailInbox;
using MediatR;

namespace MailinatorProxy.API.Features.Mails;

public static class Routes
{
    public static void RegisterMailsRoutes(this WebApplication app)
    {
        var group = app.MapGroup("/mails")
            .WithTags("Mails");

        GetMailInboxQueryEndpoint.RegisterRoute(group);
        GetMailByIdQueryEndpoint.RegisterRoute(group);
        GetMailAttachmentsQueryEndpoint.RegisterRoute(group);
    }
}
