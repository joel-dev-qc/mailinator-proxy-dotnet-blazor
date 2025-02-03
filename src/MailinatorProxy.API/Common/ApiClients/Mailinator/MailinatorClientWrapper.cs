// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using mailinator_csharp_client;
using mailinator_csharp_client.Clients.ApiClients.Authenticators;
using mailinator_csharp_client.Clients.ApiClients.Domains;
using mailinator_csharp_client.Clients.ApiClients.Messages;
using mailinator_csharp_client.Clients.ApiClients.Rules;
using mailinator_csharp_client.Clients.ApiClients.Stats;
using mailinator_csharp_client.Clients.ApiClients.Webhooks;

namespace MailinatorProxy.API.Common.ApiClients.Mailinator;

internal class MailinatorClientWrapper(string apiTokenKey) : IMailinatorClient
{
    private readonly MailinatorClient _mailinatorClient = new(apiTokenKey);

    public DomainsClient DomainsClient => _mailinatorClient.DomainsClient;
    public MessagesClient MessagesClient => _mailinatorClient.MessagesClient;
    public RulesClient RulesClient => _mailinatorClient.RulesClient;
    public StatsClient StatsClient => _mailinatorClient.StatsClient;
    public WebhooksClient WebhooksClient => _mailinatorClient.WebhooksClient;
    public AuthenticatorsClient AuthenticatorsClient => _mailinatorClient.AuthenticatorsClient;

}
