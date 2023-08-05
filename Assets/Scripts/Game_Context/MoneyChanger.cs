using System;
using Zenject;

public class MoneyChanger : IDisposable, IMoneyChanger
{
    private PlatformStatus _currentPlatfrom;

    private Timer _timer;

    private IPlayer _player;

    private int _currentLoadTimeMultiplier;
    private int _currentUnloadTimeMultiplier;

    [Inject]
    private void Construst(Timer timer, PlayerService playerService)
    {
        _timer = timer;
        _timer.OnEnded += ChangeMoney;

        _player = playerService.GetPlayer();
    }

    public void Dispose()
    {
        _timer.OnEnded -= ChangeMoney;
    }

    public void ChangeMoney()
    {
        if (_currentPlatfrom == PlatformStatus.LOAD)
        {
            _player.AddMoney();
        }
        else
        {
            _player.SpendMoney();
        }
    }

    public void GotUpOnPlatform(PlatformStatus platformStatus)
    {
        _currentPlatfrom = platformStatus;

        SetTimeMultiplier();
        StartingTimer();
    }

    private void StartingTimer()
    {
        _timer.Play();
    }

    public void LeftPlatform()
    {
        _timer.Stop();
    }

    public void ChangeLoadTimeMultiplier(int timeMultiplier)
    {
        _currentLoadTimeMultiplier = timeMultiplier;

        SetTimeMultiplier();
    }

    public void ChangeUnloadTimeMultiplier(int timeMultiplier)
    {
        _currentUnloadTimeMultiplier = timeMultiplier;

        SetTimeMultiplier();
    }

    private void SetTimeMultiplier()
    {
        if (_currentPlatfrom == PlatformStatus.LOAD)
        {
            _timer.SetCurrentMultilpier(_currentLoadTimeMultiplier);
        }
        else
        {
            _timer.SetCurrentMultilpier(_currentUnloadTimeMultiplier);
        }
    }
}