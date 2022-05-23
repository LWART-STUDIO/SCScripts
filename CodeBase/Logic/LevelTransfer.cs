
using System;
using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.States;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class LevelTransfer : MonoBehaviour
    {
        public string TransferTo;
        private IGameStateMashine _stateMashine;

        private void Awake() =>
            _stateMashine = AllServices.Container.Single<IGameStateMashine>();

        public void LoadLevel() =>
            _stateMashine.Enter<LoadLevelState,string>(TransferTo);
    }
}
