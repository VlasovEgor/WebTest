using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour
{
    public event Action<SpeedButton> OnButtonClicked;

    [SerializeField] private Button _button;
    [SerializeField] private Image _buttonImage;

    [Space]
    [SerializeField] private ButtonState _state;
    [SerializeField] private int _speedMultiplier;

    private Color _OnColor = Color.green;
    private Color _OffColor = Color.white;

    private float _sizeMultiplier = 1.2f;
    private Vector3 _startScale;

    public void Awake()
    {
        _button.onClick.AddListener(OnClick);

        _startScale = transform.localScale;
    }

    public void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        OnButtonClicked?.Invoke(this);
    }

    public int GetSpeedMultiplier()
    {
        return _speedMultiplier;
    }

    public void SetState(ButtonState state)
    {
        _state = state;

        if (_state == ButtonState.ON)
        {
            _buttonImage.color = _OnColor;
            _button.gameObject.transform.localScale *= _sizeMultiplier;
        }
        else if (_state == ButtonState.OFF)
        {
            _buttonImage.color = _OffColor;
            _button.gameObject.transform.localScale = _startScale;
        }
    }
}

public enum ButtonState
{
    ON = 0,
    OFF = 1,
}