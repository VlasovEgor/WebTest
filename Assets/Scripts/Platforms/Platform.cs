using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour
{   
    [SerializeField] private EventReceiver_Trigger _trigger;
    [SerializeField] private PlatformStatus _platformStatus;

    private IMoneyChanger _moneyStorage;

    [Inject]
    private void Construct(IMoneyChanger moneyStorage)
    {
        _moneyStorage = moneyStorage;   
    }

    private void OnEnable()
    {
        _trigger.OnTriggerEntered += OnTriggerEntered;
        _trigger.OnTriggerExited += OnTriggerExited;
    }

    private void OnDisable()
    {
        _trigger.OnTriggerEntered -= OnTriggerEntered;
        _trigger.OnTriggerExited -= OnTriggerExited;
    }

    private void OnTriggerEntered(Collider collider)
    {
        _moneyStorage.GotUpOnPlatform(_platformStatus);
    }

    private void OnTriggerExited(Collider collider)
    {
        _moneyStorage.LeftPlatform();
    }

   
}

public enum PlatformStatus
{
    LOAD = 0,
    UNLOAD =1
}