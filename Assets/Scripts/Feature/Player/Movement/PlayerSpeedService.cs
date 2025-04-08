public class PlayerSpeedService : IPlayerSpeedService
{
    private readonly PlayerEntityModel _playerEntityModel;
    private PlayerMovement _playerMovement;
    
    public PlayerSpeedService(PlayerEntityModel playerEntityModel)
    {
        _playerEntityModel = playerEntityModel;
    }

    public void SetPlayerSpeed(float playerSpeed)
    {
        _playerMovement ??= _playerEntityModel.PlayerEntity.GetComponent<PlayerMovement>();
        _playerMovement.SetPlayerSpeed(playerSpeed);
    }
}
