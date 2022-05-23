using System;
using System.Collections;
using RayFire;
using RayFire.Scripts.Components;
using UnityEngine;


namespace GAME_MAIN.CodeBase.Logic
{
    public class Bullet : MonoBehaviour
    {

        private MyGun _rayfireGun;
        private Rigidbody _rigidbody;
        private Vector3 _bulletPosition;
        

        Collider[] impactColliders;
        
        private void Awake()
        {
            //_rigidbody = GetComponent<Rigidbody>();
            _bulletPosition = transform.position;
            _rayfireGun = FindObjectOfType<MyGun>();
            StartCoroutine(DestroyDelay());

        }

        private void FixedUpdate()
        {
            _bulletPosition = transform.position;
           // transform.Translate(_rigidbody.velocity*Time.fixedDeltaTime);
            RaycastHit[] hits = Physics.RaycastAll(new Ray(_bulletPosition,
                (transform.position - _bulletPosition).normalized), (transform.position - _bulletPosition).magnitude);
            for (int i = 0; i < hits.Length; i++)
            {
                _rayfireGun.target.position = hits[i].point;
                _rayfireGun.Shoot();

                if (_rayfireGun.Hit.collider.TryGetComponent(out EnemyBodyPart enemyBodyPart))
                {
                    enemyBodyPart.GetHit();
                    
                }
                if (_rayfireGun.Hit.collider.CompareTag("Untagged"))
                {
                    Destroy(gameObject);
                }
                
            }

            Debug.DrawLine(transform.position,_bulletPosition);
        }


        private IEnumerator DestroyDelay()
        {
            yield return new WaitForSecondsRealtime(3f);
            Destroy(gameObject);
        }
    }
}
