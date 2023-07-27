using Code.Audio;
using Zenject;

namespace Code.Infrastructure.Installers.ProjectInstaller
{
    public class SceneAudioInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneAudioController();
        }

        private void BindSceneAudioController()
        {
            Container.Bind<SceneAudioController>().AsSingle().NonLazy();
        }
    }
}