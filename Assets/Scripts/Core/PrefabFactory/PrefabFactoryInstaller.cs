public class PrefabFactoryInstaller : Installer<PrefabFactoryInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IPrefabFactory>().To<PrefabsFactory>().AsSingle();
    }
}
