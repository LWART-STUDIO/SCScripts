namespace GAME_MAIN.CodeBase.Infrastructure.States
{
    public interface IState:IExitableState
    {
        void Enter();
    }
    public interface IPayloadedIState<TPayload> : IExitableState
    {
        void  Enter(TPayload payload);
    }
    public interface IExitableState
    {
        void Exit();
    }
}