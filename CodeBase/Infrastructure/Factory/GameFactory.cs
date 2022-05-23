using System.Collections.Generic;
using GAME_MAIN.CodeBase.Enemy;
using GAME_MAIN.CodeBase.Infrastructure.AssetManagement;
using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
using GAME_MAIN.CodeBase.Infrastructure.States;
using GAME_MAIN.CodeBase.Logic;
using GAME_MAIN.CodeBase.StaticData;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private GameObject _heroGameObject;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets,IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreateHud(GameStateMachine stateMachine)
        {
        GameObject hud=InstantiateRegistered(AssetPath.HudPath);

        SnipeMove snipeMove = hud.GetComponentInChildren<SnipeMove>();
        snipeMove.PointToShoot = _heroGameObject.GetComponentInParent<InitPoint>().gameObject.transform;
        snipeMove.MoveTarget =_heroGameObject.GetComponentInParent<InitPoint>().gameObject;
        hud.GetComponentInChildren<MainCanvasMarker>().gameObject.SetActive(false);
        var restartLevel = hud.GetComponentInChildren<RestartLevel>();
        restartLevel.Construct(stateMachine);
        restartLevel.gameObject.SetActive(false);
        return hud;
        }
            

        public GameObject CreateHero(GameObject at)
        {
            _heroGameObject=InstantiateRegistered(AssetPath.HeroPath, at.transform.position,at.transform);
            return _heroGameObject;
        }
            

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId, Transform parent)
        {
           EnemyStaticData enemyData= _staticData.ForEnemy(enemyTypeId);
           GameObject enemy=Object.Instantiate(enemyData.ModelPrefab, parent.position, Quaternion.identity, parent);
           
           var health = enemy.GetComponentInChildren<IHealth>();
           health.Current = enemyData.Hp;
           health.Max = enemyData.Hp;

           var attack = enemy.GetComponentInChildren<Attack>();
           attack.Constract(_heroGameObject.transform);
           attack.Damage = enemyData.Damage;
           
           enemy.GetComponentInChildren<RotateToHero>()?.Constract(_heroGameObject.transform);
           
           return enemy;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressesWriters.Clear();
        }


        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        private GameObject InstantiateRegistered(string prefabPath, Vector3 at,Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath,at,parent);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        public void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressesWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
                
        }
    }
}
