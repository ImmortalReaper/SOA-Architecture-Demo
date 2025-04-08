using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSliderView : MonoBehaviour, ISpeedSliderView
{
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private TextMeshProUGUI _currentSpeedText;
    
    public event Action<float> OnValueChanged;

    private void Awake()
    {
        _currentSpeedText.text = _speedSlider.value.ToString("0.0");
        _speedSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy() =>
        _speedSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    
    private void OnSliderValueChanged(float value)
    {
        _currentSpeedText.text = value.ToString("0.0");
        OnValueChanged?.Invoke(value);
    }
    
    public void SetSpeed(float playerSpeed)
    {
        _speedSlider.value = playerSpeed;
        _currentSpeedText.text = playerSpeed.ToString("0.0");
    }
}
