// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MailinatorProxy.Shared.Dtos.Mails;

namespace MailinatorProxy.Web.States;

public class InboxListState
{
    private readonly Dictionary<string, DomainInboxState> _domainStates = new();

    public event Action<string>? OnChanged;

    public DomainInboxState GetOrCreateDomainState(string domain)
    {
        if (!_domainStates.TryGetValue(domain, out var state))
        {
            state = new DomainInboxState();
            _domainStates[domain] = state;
        }
        return state;
    }

    public void ClearState(string domain)
    {
        if (_domainStates.ContainsKey(domain))
        {
            _domainStates[domain] = new DomainInboxState();
            OnChanged?.Invoke(domain);
        }
    }

    public class DomainInboxState
    {
        public List<MessageDto> Messages { get; set; } = new();
        public Dictionary<string, bool> ReadStates { get; set; } = new();
        public int CurrentOffset { get; set; } = 0;
        public bool HasMoreData { get; set; } = true;
        public string CurrentInbox { get; set; } = "*";
    }
}
