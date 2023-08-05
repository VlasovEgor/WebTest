using UnityEngine;

public class PlayerService : MonoBehaviour
{
    [SerializeField] private Player _player;

    public IPlayer GetPlayer()
    {
        return _player;
    }
}
