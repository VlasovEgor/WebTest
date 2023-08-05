using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Wallet _wallet;

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
}
