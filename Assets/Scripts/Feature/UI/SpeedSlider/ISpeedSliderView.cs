using System;

namespace Feature.UI.SpeedSlider
{
    public interface ISpeedSliderView
    {
        public event Action<float> OnValueChanged;
        public void SetSpeed(float playerSpeed);
    }
}
