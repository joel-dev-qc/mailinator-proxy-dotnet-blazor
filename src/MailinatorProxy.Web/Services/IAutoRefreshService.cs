// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MailinatorProxy.Web.Services;

public interface IAutoRefreshService
{
    bool IsEnabled { get; }
    int Countdown { get; }
    DateTime? LastUpdatedUtc { get; }

    event Action OnCountdownChanged;
    event Action OnRefreshInitiated;

    void Initialize(int refreshIntervalSeconds, Func<Task> onRefresh);
    void Toggle();
    void ResetCountdown();
    Task RefreshAsync();
}
