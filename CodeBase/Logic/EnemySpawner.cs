using System.Collections.Generic;
using GAME_MAIN.CodeBase.Data;
using GAME_MAIN.CodeBase.Enemy;
using GAME_MAIN.CodeBase.Infrastructure.Factory;
using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
using GAME_MAIN.CodeBase.StaticData;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class EnemySpawner:MonoBehaviour,ISavedProgress
    {
        public EnemyTypeId EnemyTypeId;
        private string _id;
        [SerializeField] private bool _slain;
        private IGameFactory _factory;
        private EnemyDeath _enemyDeath;
        public EnemyControll Enemy;
        public bool Slain => _slain;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        public void Spawn()
        {
           var enemy= _factory.CreateEnemy(EnemyTypeId, transform);
           _enemyDeath = enemy.GetComponentInChildren<EnemyDeath>();
           _enemyDeath.Happaned += Slay;
           Enemy = enemy.GetComponentInChildren<EnemyControll>();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearedSpawners.Contains(_id))
                _slain = true;
            else
            {
                Spawn();
            }
        }

        private void Slay()
        {
            if(_enemyDeath!=null) 
                _enemyDeath.Happaned -= Slay;
            
            _slain = true;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            List<string> slainSpawnersList = progress.KillData.ClearedSpawners;
            if(_slain&& !slainSpawnersList.Contains(_id))
                slainSpawnersList.Add(_id);
            progress.KillData.ClearedSpawners = slainSpawnersList;
        }
    }
}