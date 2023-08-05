using UnityEngine;

public class CameraService : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransfrom;

    public Transform GetCameraTransfrom()
    {
        return _cameraTransfrom;
    }
}
