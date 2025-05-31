// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.States;

public class DomainState
{
    private string? _domain;

    public string? Current => _domain;

    public event Action? OnChanged;

    public void Set(string domain)
    {
        if (_domain != domain)
        {
            _domain = domain;
            OnChanged?.Invoke();
        }
    }

    public void Clear()
    {
        _domain = null;
        OnChanged?.Invoke();
    }
}
