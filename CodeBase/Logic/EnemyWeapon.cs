using System;
using GAME_MAIN.CodeBase.Enemy;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefub;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _bulletSpeed;
        private GameObject _player;
        private EnemyControll _enemyControll;

        private void Awake()
        {
            _enemyControll = GetComponentInParent<EnemyControll>();
            _player = FindObjectOfType<Herro>().gameObject;
        }

        public void Shoot()
        {
            GameObject bullet = Instantiate(_bulletPrefub, _shootPoint.position,Quaternion.identity);
            bullet.name = "EnemyBullet";
            EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
            enemyBullet.Target = _player.transform;
            enemyBullet.Speed = _bulletSpeed;
            enemyBullet.enemyControll = _enemyControll;
            enemyBullet.StartMove = true;
        }
    }
}
