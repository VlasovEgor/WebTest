using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public event Action<int> OnMoneyChanged;

    [SerializeField] private Movement _movement;
    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        _wallet.OnMoneyChanged += MoneyChanged;
    }

    private void OnDestroy()
    {
        _wallet.OnMoneyChanged -= MoneyChanged;
    }

    public Transform GetPlayerTransfrom()
    {
        return transform;
    }

    public void Move(Vector3 offset)
    {
        _movement.Move(offset);
    }

    public void AddMoney()
    {
        _wallet.AddMoney();
    }

    public void SpendMoney()
    {
        _wallet.SpendMoney();
    }

    private void MoneyChanged(int money)
    {
        OnMoneyChanged?.Invoke(money);  
    }
}
