using System;
using UnityEngine;

public interface IPlayer
{
    public event Action<int> OnMoneyChanged;

    public void AddMoney();
    public Transform GetPlayerTransfrom();
    public void Move(Vector3 offset);
    public void SpendMoney();
}