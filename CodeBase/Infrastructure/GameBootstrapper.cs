using GAME_MAIN.CodeBase.Infrastructure.States;
using GAME_MAIN.CodeBase.Logic;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour,ICorutibeRunner
    {
        public LoadingCurtain CurtainPrefab;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this,Instantiate(CurtainPrefab));
            _game.StateMachine.Enter<BootsrapState>();
            DontDestroyOnLoad(this);
        }
    }
}

