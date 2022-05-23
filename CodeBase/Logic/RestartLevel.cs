using GAME_MAIN.CodeBase.Infrastructure.States;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class RestartLevel : MonoBehaviour
    {
    
        private const string PlayerTag = "Player";
         string TransferTo="Level1";
        private GameStateMachine _stateMachine;
        private bool _triggered;

        public void Construct(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

      

        public void Restart()
        {

            _stateMachine.Enter<LoadLevelState, string>(TransferTo);

        }
    }

    
}
