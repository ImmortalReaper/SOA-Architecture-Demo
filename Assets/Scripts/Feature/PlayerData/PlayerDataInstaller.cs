using Addressables;
using Core.AssetLoader;
using Core.Installer;
using Feature.Player.Movement;

namespace Feature.PlayerData
{
    public class PlayerDataInstaller : Installer<PlayerDataInstaller>
    {
        public override void InstallBindings()
        {
            IAddressablesAssetLoaderService addressablesAssetLoaderService = Container.Resolve<IAddressablesAssetLoaderService>();
            Container.Bind<PlayerConfig>()
                .FromScriptableObject(addressablesAssetLoaderService.LoadAsset<PlayerConfig>(Address.Configs.PlayerConfig))
                .AsSingle();
            Container.Bind<PlayerEntityModel>().AsSingle();
            Container.Bind<IPlayerSpeedService>().To<PlayerSpeedService>().AsSingle();
        }
    }
}
