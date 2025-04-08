using Feature.Player.Movement;
using Feature.PlayerData;
using UnityEngine;
using Zenject;

namespace Feature.UI.SpeedSlider
{
    public class SpeedSliderController : MonoBehaviour
    {
        private ISpeedSliderView _speedSliderView;
        private IPlayerSpeedService _playerSpeedService;
        private PlayerConfig _playerConfig;

        [Inject]
        public void InjectDependencies(IPlayerSpeedService playerSpeedService, PlayerConfig playerConfig)
        {
            _playerSpeedService = playerSpeedService;
            _playerConfig = playerConfig;
        }
    
        private void Start()
        {
            _speedSliderView = GetComponent<ISpeedSliderView>();
            _speedSliderView.OnValueChanged += SpeedChanged;
            _speedSliderView.SetSpeed(_playerConfig.PlayerSpeed);
        }

        private void OnDestroy()
        {
            _speedSliderView.OnValueChanged -= SpeedChanged;
        }

        private void SpeedChanged(float speed) =>
            _playerSpeedService.SetPlayerSpeed(speed);
    }
}
