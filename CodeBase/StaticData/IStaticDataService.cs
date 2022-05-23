using GAME_MAIN.CodeBase.Infrastructure.Services;

namespace GAME_MAIN.CodeBase.StaticData
{
    public interface IStaticDataService:IService
    {
         void LoadEnemys();
         EnemyStaticData ForEnemy(EnemyTypeId typeId);
    }
}