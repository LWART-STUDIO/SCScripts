
using GAME_MAIN.CodeBase.Logic;

namespace GAME_MAIN.CodeBase.Enemy
{
    public interface IAnimationStateReader
    {
        void EnteredState(int stateHash);
        void ExitedState(int stateHash);
        AnimatorState State { get; }
    }
}