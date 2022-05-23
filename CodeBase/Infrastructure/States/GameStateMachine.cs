using System;
using System.Collections.Generic;
using GAME_MAIN.CodeBase.Infrastructure.Factory;
using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
using GAME_MAIN.CodeBase.Infrastructure.Services.SaveLoad;
using GAME_MAIN.CodeBase.Logic;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMashine
    {
        private Dictionary<Type,IExitableState> _states;
        private IExitableState _activeState;
        
        public GameStateMachine(SceneLoader sceneLoader,LoadingCurtain curtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
         
            {
                [typeof(BootsrapState)] = new BootsrapState(this,sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this,sceneLoader,curtain,services.Single<IGameFactory>(),services.Single<IPersistentProgressService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this,services.Single<IPersistentProgressService>(),services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this,sceneLoader),
                
            };
        }
        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }
        public void Enter<TState,TPayload>(TPayload payload) where TState : class, IPayloadedIState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }
        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}
