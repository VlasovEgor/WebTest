using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour
{
    private Transform _cameraPosition;
    private Transform _playerPosition;

    [Inject]
    private void Construct(PlayerService playerService, CameraService cameraService)
    {
        _cameraPosition = cameraService.GetCameraTransfrom();
        _playerPosition = playerService.GetPlayer().GetPlayerTransfrom();
    }

    private void Update()
    {
        _cameraPosition.position = _playerPosition.position;
    }

}
