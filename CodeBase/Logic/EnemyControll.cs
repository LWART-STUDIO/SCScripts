using System;
using System.Collections;
using GAME_MAIN.CodeBase.Enemy;
using GAME_MAIN.CodeBase.StaticData;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    [RequireComponent(typeof(RotateToHero))]
    [RequireComponent(typeof(Attack))]
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyControll : MonoBehaviour
    {

        public float TimeToAtack;
        [SerializeField] private bool _rotateToHerro;
        [SerializeField] private bool _startAtack;
        private RotateToHero _rotateToHero;
        private Attack _attack;
       [SerializeField] private EnemyHealth _health;
       
        

        private void Awake()
        {
            _rotateToHero = GetComponent<RotateToHero>();
            _attack = GetComponent<Attack>();
            _health = GetComponent<EnemyHealth>();
        }



        private void Update()
        {
            if (_rotateToHerro)
            {
                LookAtPlayer();
            }

            if (_startAtack)
            {
                StartAtack();
            }
        }

        public void TakeHit(BodyParts part)
        {
            switch (part)
            {
                case BodyParts.Body:
                    _health.TakeDamage(1);
                    break;
                case BodyParts.Head:
                    _health.TakeDamage(_health.Max);
                    break;
                case BodyParts.LeftHand:
                    _health.TakeDamage(1);
                    break;
                case BodyParts.LeftLeg:
                    _health.TakeDamage(1);
                    break;
                case BodyParts.RightHand:
                    _health.TakeDamage(1);
                    break;
                case BodyParts.RightLeg:
                    _health.TakeDamage(1);
                    break;
                
            }
        }

        public void LookAtPlayer()
        {
            _rotateToHero.Speed = 2f;
        }

        public void StartAtack()
        {
            StartCoroutine(WaitToAtack());
        }

        public void Atack()
        {
            _attack.StartAttack();
        }

        public void StopAtack()
        {
            StopAllCoroutines();
            _attack.DisableAttack();
        }
        private IEnumerator WaitToAtack()
        {
            LookAtPlayer();
            yield return new WaitForSeconds(TimeToAtack);
            _attack.EnableAttack();
        }
    }
}
