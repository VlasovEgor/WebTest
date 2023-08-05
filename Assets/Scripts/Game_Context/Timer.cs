using System;
using UnityEngine;
using Zenject;

public class Timer : ITickable
{
    public event Action OnEnded;

    public float Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    private float _duration = 1;

    private float _currentTime;

    private int _currentMultiplier;

    private bool _isPlaying;

    public void Play()
    {
        _isPlaying = true;
    }

    public void Stop()
    {
        _isPlaying = false;
    }

    public void SetCurrentMultilpier(int timeMultilpier)
    {
        _currentMultiplier = timeMultilpier;
    }

    public void Tick()
    {
        if (_isPlaying == true)
        {
            if (_currentTime < _duration)
            {
                _currentTime += Time.deltaTime * _currentMultiplier;
            }
            else
            {
                _currentTime = 0;
                OnEnded?.Invoke();
            }
        }
    }
}