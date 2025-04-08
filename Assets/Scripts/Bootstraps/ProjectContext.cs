using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ProjectContext", menuName = "Installers/ProjectContext")]
public class ProjectContext : ScriptableObjectInstaller<ProjectContext>
{
    public override void InstallBindings()
    {
        AdressablesAssetLoaderInstaller.Install(Container);
    }
}