using System;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class Herro : MonoBehaviour
    {
        private PlayerRotator _playerRotator;
        private SnipeMove _snipeMove;

        private void Awake()
        {
            _playerRotator = FindObjectOfType<PlayerRotator>();
            
        }

        public void GetHit()
        {
            if (_snipeMove == null)
            {
                _snipeMove = FindObjectOfType<SnipeMove>();
            }

            _snipeMove.CanAtack = false;
            _snipeMove.Restart();
            _snipeMove.enabled = false;
            _playerRotator.Speed = 0f;
            Debug.Log("Player get Hit");
        }
    }
}
