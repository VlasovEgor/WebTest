using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller    
{
    [SerializeField] private PlayerService _playerService;
    [SerializeField] private MoveController moveController;
    [SerializeField] private GameObject _moneyPrefab;

    public override void InstallBindings()
    {
        BindPlayerService();
        BindMoveController();
        BindMoneyPool();
    }

    private void BindPlayerService()
    {
        Container.Bind<PlayerService>().
            FromInstance(_playerService).
            AsSingle();
    }

    private void BindMoveController()
    {
        Container.BindInterfacesAndSelfTo<MoveController>().
            AsSingle();
    }

    private void BindMoneyPool()
    {
        Container.BindMemoryPool<Money, MoneyPool>().
            WithInitialSize(100).
            ExpandByOneAtATime().
            FromComponentInNewPrefab(_moneyPrefab).
            UnderTransform(_playerService.GetPlayer().GetPlayerTransfrom());
    }
}