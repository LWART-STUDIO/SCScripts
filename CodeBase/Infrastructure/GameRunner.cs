using System;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper BootstrapperPrefaab;
        private void Awake()
        {
            var bootstraper = FindObjectOfType<GameBootstrapper>();

            if (bootstraper == null) 
                Instantiate(BootstrapperPrefaab);
        }
    }
}