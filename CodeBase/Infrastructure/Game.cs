using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.States;
using GAME_MAIN.CodeBase.Logic;

namespace GAME_MAIN.CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICorutibeRunner coroutineRunner,LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner),curtain, AllServices.Container);
        }

        
    }
}
