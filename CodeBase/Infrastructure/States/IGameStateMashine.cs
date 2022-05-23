using GAME_MAIN.CodeBase.Infrastructure.Services;

namespace GAME_MAIN.CodeBase.Infrastructure.States
{
    public interface IGameStateMashine:IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState,TPayload>(TPayload payload) where TState : class, IPayloadedIState<TPayload>;
    }
}