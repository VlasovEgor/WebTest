using System;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public event Action<ButtonsType, int> SpeedMultiplierChanged;

    [SerializeField] private ButtonsType _buttonType;
    [SerializeField] private List<SpeedButton> _buttons = new();

    private void Awake()
    {
        foreach (var button in _buttons)
        {
            button.OnButtonClicked += OnClick;
        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            button.OnButtonClicked -= OnClick;
        }
    }

    void OnClick(SpeedButton speedButton)
    {
        foreach (var button in _buttons)
        {   
            if(button == speedButton) 
            {
                button.SetState(ButtonState.ON);

                SpeedMultiplierChanged?.Invoke(_buttonType, button.GetSpeedMultiplier());
            }
            else
            {
                button.SetState(ButtonState.OFF);
            }
        }
    }
}

public enum ButtonsType
{
    LOAD = 0,
    UNLOAD = 1
}