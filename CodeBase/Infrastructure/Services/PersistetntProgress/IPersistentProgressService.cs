using GAME_MAIN.CodeBase.Data;

namespace GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress
{
    public interface IPersistentProgressService:IService
    {
        PlayerProgress Progress { get; set; }
    }
}
