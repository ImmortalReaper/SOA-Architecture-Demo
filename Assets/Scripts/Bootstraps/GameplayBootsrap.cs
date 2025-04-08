using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplayBootsrap", menuName = "Installers/GameplayBootsrap")]
public class GameplayBootsrap : ScriptableObjectInstaller<GameplayBootsrap>
{
    public override void InstallBindings()
    {
        PrefabFactoryInstaller.Install(Container);
        PlayerDataInstaller.Install(Container);
        CommandModuleInstaller.Install(Container);
    }
}