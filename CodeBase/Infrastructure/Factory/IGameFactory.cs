using System.Collections.Generic;
using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
using GAME_MAIN.CodeBase.Infrastructure.States;
using GAME_MAIN.CodeBase.StaticData;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory: IService
    {
        GameObject CreateHero(GameObject at);
        GameObject CreateHud(GameStateMachine stateMachine);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        void Cleanup();
        void Register(ISavedProgressReader progressReader);


        GameObject CreateEnemy(EnemyTypeId enemyTypeId, Transform parent);
    }
}
