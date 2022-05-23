
    using UnityEngine;
    using UnityEngine.SceneManagement;

    namespace GAME_MAIN.CodeBase.Infrastructure.States
    {
        public class GameLoopState : IState
        {
            private string _thisScene;
            private readonly GameStateMachine _stateMachine;
            private readonly SceneLoader _sceneLoader;

            public GameLoopState(GameStateMachine stateMachine,SceneLoader sceneLoader)
            {
                _stateMachine = stateMachine;
                _sceneLoader = sceneLoader;
            }

            public void Exit()
            {
            
            }

            public void Enter()
            {

                
            }

            
        }
    }
