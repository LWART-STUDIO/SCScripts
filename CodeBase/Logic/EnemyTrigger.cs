using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class EnemyTrigger : MonoBehaviour
    {

        [SerializeField] private List<EnemySpawner> _enemySpawners;
        private bool _startWatching;


        private void Update()
        {
            if (_startWatching)
            {
                
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Herro hero))
            {
                
                foreach (EnemySpawner enemySpawner in _enemySpawners)
                {
                    if (enemySpawner.Slain == false)
                    {
                        var enemyControll = enemySpawner.Enemy;
                        enemyControll.StartAtack();
                    }
                    
                }

                _startWatching = true;
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            
            if (other.TryGetComponent(out Herro hero))
            {
                foreach (EnemySpawner spawner in _enemySpawners)
                {
                    if (spawner.Slain == false)
                    {
                        var enemyControll = spawner.Enemy;
                        enemyControll.Atack();
                        return;
                    }
                }
            }
            
        }
    }
}
