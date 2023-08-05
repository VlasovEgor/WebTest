using System;
using UnityEngine;
using Zenject;

public class MoveController : IInitializable, IDisposable
{
    private IInput _input;
    private IPlayer _player;

    [Inject]
    public void Construct(IInput input, PlayerService playerService)
    {
        _input = input;
        _player = playerService.GetPlayer();
    }

    public void Initialize()
    {
        _input.OnMove += Move;
    }

    public void Dispose()
    {
        _input.OnMove -= Move;
    }

    public void Move(Vector3 offset)
    {
        _player.Move(offset);
    }
}