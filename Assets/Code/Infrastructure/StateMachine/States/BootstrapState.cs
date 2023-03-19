using Code.Data.ProgressData;
using Code.Debugers;
using Code.Services;
using FMOD;

namespace Code.Infrastructure.StateMachine.States
{

    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly PersistentSavedDataService _persistentSavedDataService;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader,PersistentSavedDataService persistentSavedDataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _persistentSavedDataService = persistentSavedDataService;
        }

        public void Enter()
        {
            _sceneLoader.Load(Constants.initialScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _persistentSavedDataService.LoadData();
          
            var level = _persistentSavedDataService
                .savedData
                .heroPositionData
                .level;
            
            _stateMachine.Enter<LoadLevelState, string>(level);
        }
    }
}