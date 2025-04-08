using Core.Installer;

namespace Feature.Commands
{
    public class CommandModuleInstaller : Installer<CommandModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CommandQueue>().AsCached();
            Container.BindInterfacesAndSelfTo<PlayerCommandHandler>().AsSingle();
        }
    }
}
