
    using GAME_MAIN.CodeBase.Data;
    using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
    using GAME_MAIN.CodeBase.Infrastructure.Services.SaveLoad;
    using UnityEngine.SceneManagement;

    namespace GAME_MAIN.CodeBase.Infrastructure.States
    {
        public class LoadProgressState : IState
        {
            private readonly GameStateMachine _gameStateMachine;
            private readonly IPersistentProgressService _progressService;
            private readonly ISaveLoadService _saveLoadService;

            public LoadProgressState(GameStateMachine gameStateMachine,IPersistentProgressService progressService, ISaveLoadService saveLoadService)
            {
                _gameStateMachine = gameStateMachine;
                _progressService = progressService;
                _saveLoadService = saveLoadService;
            }

            public void Enter()
            {
                LoadProgressOrInitNew();
                _gameStateMachine.Enter<LoadLevelState,string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
            }

            public void Exit()
            {
            
            }

            private void LoadProgressOrInitNew() =>
                _progressService.Progress = 
                    _saveLoadService.LoadProgress() 
                    ?? NewProgress();

            private PlayerProgress NewProgress() => 
                new PlayerProgress("Level1");
        }
    }
