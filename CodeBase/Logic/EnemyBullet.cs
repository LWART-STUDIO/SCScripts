using System;
using Ballistics;
using GAME_MAIN.CodeBase.Enemy;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class EnemyBullet : MonoBehaviour
    {
        public Transform Target;
        public float Speed;
        public bool StartMove;
        
        public EnemyControll enemyControll;

        

        private void FixedUpdate()
        {
            if (StartMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed);
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Herro herro))
            {
                enemyControll.StopAtack();
                herro.GetHit();
                Destroy(gameObject);
            }
        }
    }
}
