using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class FloorTrigger : MonoBehaviour
    {
        [SerializeField] private PlayerRotator _playerRotator;
        [SerializeField] private List<EnemySpawner> _enemySpawners;
        private bool _slain;

        private void Awake()
        {
            _playerRotator = FindObjectOfType<PlayerRotator>();
            StartCoroutine(WaitToUp());
        }



        private IEnumerator WaitToUp()
        {
            while (!_slain)
            {
                if (_enemySpawners.All(x => x.Slain == true))
                {
                    _slain = true;
                    _playerRotator.MoveUp();
                    Debug.Log("MoveUp");
                }
                yield return null;
            }
            
        }
    }
}