using System;
using UnityEngine;
using Zenject;

public class KeyboardInput : IInput, ITickable
{
    public event Action<Vector3> OnMove;

    public void Tick()
    {
        Move();
    }

    private void Move()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        OnMove?.Invoke(inputVector);
    }
}
