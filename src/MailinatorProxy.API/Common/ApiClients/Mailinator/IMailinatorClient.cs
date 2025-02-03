// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client.Clients.ApiClients.Authenticators;
using mailinator_csharp_client.Clients.ApiClients.Domains;
using mailinator_csharp_client.Clients.ApiClients.Messages;
using mailinator_csharp_client.Clients.ApiClients.Rules;
using mailinator_csharp_client.Clients.ApiClients.Stats;
using mailinator_csharp_client.Clients.ApiClients.Webhooks;

namespace MailinatorProxy.API.Common.ApiClients.Mailinator;

internal interface IMailinatorClient
{
    public DomainsClient DomainsClient { get; }

    public MessagesClient MessagesClient { get; }

    public RulesClient RulesClient { get; }

    public StatsClient StatsClient { get; }

    public WebhooksClient WebhooksClient { get; }

    public AuthenticatorsClient AuthenticatorsClient { get; }
}
