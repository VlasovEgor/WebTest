using UnityEngine;

public interface IPlayer
{
    void AddMoney();
    Transform GetPlayerTransfrom();
    void Move(Vector3 offset);
    void SpendMoney();
}