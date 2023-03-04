using Code.Data.DataPersistence;
using Code.Infrastructure.Factory.States;
using Code.Logic;
using Code.Logic.DayOfTime;
using Code.Services;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>, IInitializable, ICoroutineRunner
    {
        public bool isBindStateMachine = true;
        public LoadingCurtain curtain;
    
        public override void InstallBindings()
        {
            BindInterfaces();

            BindDataManager();
            BindStateMachine();
        
            BindTimeOfDayController();
        }

        public void Initialize() => 
            Container.Resolve<GameStateMachine>().Enter<BootstrapState>();

        private void BindInterfaces() =>
            Container.BindInterfacesTo<GameInstaller>()
                .FromInstance(this);

        private  void BindDataManager() => 
            Container.Bind<ProgressService>().FromComponentInChildren();

        private void BindStateMachine()
        {
            if(!isBindStateMachine)
                return;
        
            Container.Bind<GameStateMachine>()
                .AsSingle().WithArguments(new SceneLoader(this), curtain).NonLazy();
        }

        private void BindTimeOfDayController() => 
            Container.BindInterfacesAndSelfTo<TimeOfDayController>().AsSingle().NonLazy();
    }
}


