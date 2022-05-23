using GAME_MAIN.CodeBase.Data;

namespace GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}
