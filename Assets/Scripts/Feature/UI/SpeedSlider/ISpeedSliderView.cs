using System;

public interface ISpeedSliderView
{
    public event Action<float> OnValueChanged;
    public void SetSpeed(float playerSpeed);
}
