using Timer = System.Timers.Timer;

namespace MailinatorProxy.Web.Services;

public class AutoRefreshService : IAutoRefreshService, IDisposable
{
    private readonly ILogger<AutoRefreshService> _logger;
    private Timer _timer;
    private bool _isDisposed;
    private Func<Task> _onRefreshCallback;
    private int _refreshIntervalSeconds;

    public AutoRefreshService(ILogger<AutoRefreshService> logger)
    {
        _logger = logger;
    }

    public bool IsEnabled { get; private set; } = true;
    public int Countdown { get; private set; }
    public DateTime? LastUpdatedUtc { get; private set; }
    public event Action OnCountdownChanged;
    public event Action OnRefreshInitiated;

    public void Initialize(int refreshIntervalSeconds, Func<Task> onRefresh)
    {
        _onRefreshCallback = onRefresh;
        _refreshIntervalSeconds = refreshIntervalSeconds;
        Countdown = refreshIntervalSeconds;

        _timer?.Dispose();
        _timer = new Timer(1000); // Tick every second
        _timer.Elapsed += async (_, _) => await TimerElapsedAsync();
        _timer.Start();
    }

    private async Task TimerElapsedAsync()
    {
        if (_isDisposed || !IsEnabled)
            return;

        Countdown--;
        OnCountdownChanged?.Invoke();

        if (Countdown <= 0)
        {
            ResetCountdown();
            await RefreshAsync();
        }
    }

    public void Toggle()
    {
        IsEnabled = !IsEnabled;
        ResetCountdown();
        OnCountdownChanged?.Invoke();
    }

    public void ResetCountdown()
    {
        if (_timer != null)
        {
            Countdown = _refreshIntervalSeconds;
            OnCountdownChanged?.Invoke();
        }
    }

    public async Task RefreshAsync()
    {
        if (_onRefreshCallback == null) return;

        OnRefreshInitiated?.Invoke();
        try
        {
            await _onRefreshCallback.Invoke();
            LastUpdatedUtc = DateTime.UtcNow;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Auto-refresh failed.");
        }

        OnCountdownChanged?.Invoke();
    }

    public void Dispose()
    {
        _isDisposed = true;
        _timer?.Dispose();
        _timer = null;
    }
}
