using System;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class LevelRotator : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public float SpeedFx=1;

        private void FixedUpdate()
        {
            transform.Rotate(0,_speed*SpeedFx,0,Space.Self);
        }
    }
}
