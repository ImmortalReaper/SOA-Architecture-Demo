public class AdressablesAssetLoaderInstaller : Installer<AdressablesAssetLoaderInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IAddressablesAssetLoaderService>().To<AddressablesAssetLoaderService>().AsSingle();
    }
}
