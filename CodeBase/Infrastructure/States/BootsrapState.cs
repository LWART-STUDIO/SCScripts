using GAME_MAIN.CodeBase.Infrastructure.AssetManagement;
using GAME_MAIN.CodeBase.Infrastructure.Factory;
using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
using GAME_MAIN.CodeBase.Infrastructure.Services.SaveLoad;
using GAME_MAIN.CodeBase.StaticData;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure.States
{
    public class BootsrapState:IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootsrapState(GameStateMachine stateMachine,SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterService();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial,onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void RegisterService()
        {
            RegisterStaticData();
            _services.RegisterSingle<IAssets>(new AssetProvider() );
            _services.RegisterSingle<IGameStateMashine>(_stateMachine);
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>(),_services.Single<IStaticDataService>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(),_services.Single<IGameFactory>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadEnemys();
            _services.RegisterSingle<IStaticDataService>(staticData);
        }
    }
}
