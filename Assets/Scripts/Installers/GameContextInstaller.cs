using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{
    [SerializeField] private CameraService _cameraService;

    public override void InstallBindings()
    {
        BindKeyboardInput();

        BindCameraService();
        BindTimer();

        BindMoneyChanger();
    }

    private void BindKeyboardInput()
    {
        Container.BindInterfacesAndSelfTo<KeyboardInput>().
            AsSingle();
    }

    private void BindCameraService()
    {
        Container.Bind<CameraService>().
            FromInstance(_cameraService).
            AsSingle();
    }

    private void BindTimer()
    {
        Container.BindInterfacesAndSelfTo<Timer>().
            AsSingle();
    }

    private void BindMoneyChanger()
    {
        Container.BindInterfacesAndSelfTo<MoneyChanger>().
            AsSingle();
    }
}