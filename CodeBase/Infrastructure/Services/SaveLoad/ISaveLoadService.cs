using GAME_MAIN.CodeBase.Data;

namespace GAME_MAIN.CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService:IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}
