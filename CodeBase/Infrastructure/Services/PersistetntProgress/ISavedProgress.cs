using GAME_MAIN.CodeBase.Data;

namespace GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
    }
