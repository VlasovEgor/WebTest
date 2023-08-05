using UnityEngine;
using Zenject;

public class ButtonsAdapter : MonoBehaviour
{
    [SerializeField] private Buttons _loadButtons;
    [SerializeField] private Buttons _unloadButton;

    private IMoneyChanger _moneyChanger;

    [Inject]
    private void Construct(IMoneyChanger moneyChanger)
    {
        _moneyChanger = moneyChanger;
    }

    private void Awake()
    {
        _loadButtons.SpeedMultiplierChanged += OnSpeedMultiplierChanged;
        _unloadButton.SpeedMultiplierChanged += OnSpeedMultiplierChanged;
    }

    private void OnDestroy()
    {
        _loadButtons.SpeedMultiplierChanged -= OnSpeedMultiplierChanged;
        _unloadButton.SpeedMultiplierChanged -= OnSpeedMultiplierChanged;
    }

    private void OnSpeedMultiplierChanged(ButtonsType type, int speedMultiplier)
    {
        if (type == ButtonsType.LOAD)
        {
            _moneyChanger.ChangeLoadTimeMultiplier(speedMultiplier);
        }
        else
        {
            _moneyChanger.ChangeUnloadTimeMultiplier(speedMultiplier);
        }
    }
}
