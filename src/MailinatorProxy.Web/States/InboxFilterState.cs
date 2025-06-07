// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.States;

public class InboxFilterState
{
    public string CurrentInbox { get; set; } = "*";

    public event Action? OnChanged;

    public void SetInbox(string inbox)
    {
        CurrentInbox = inbox;
        OnChanged?.Invoke();
    }
}
