using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Wallet : MonoBehaviour
{
    private MoneyPool _moneyPool;
    private List<Money> _acctiveMoney = new();

    private int _amountMoneyInColumn = 10;
    private float _xOffset = 0.2f;
    private float _yOffset = 0.1f;

    [Inject]
    private void Construct(MoneyPool moneyPool)
    {
        _moneyPool = moneyPool;
    }

    public void AddMoney()
    {
        var money = _moneyPool.Spawn();
        _acctiveMoney.Add(money);

        SpawnMoney(money);
    }

    private void SpawnMoney(Money money)
    {
        Vector3 currentPosition = transform.position +
            new Vector3(
                _xOffset * (_acctiveMoney.Count / _amountMoneyInColumn), 
                _yOffset * (_acctiveMoney.Count % _amountMoneyInColumn),
                0
                );
        money.transform.position = currentPosition;
    }

    public void SpendMoney()
    {
        if (_acctiveMoney.Count > 0)
        {
            var money = _acctiveMoney.Last();
            _moneyPool.Despawn(money);
            _acctiveMoney.Remove(money);
        }
    }
}