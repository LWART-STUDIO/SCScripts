using System;
using System.Collections;
using Ballistics;
using UnityEngine;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


namespace GAME_MAIN.CodeBase.Logic
{
    public class SnipeMove : MonoBehaviour, IDragHandler
    {
        [SerializeField] private Transform _aimTarget;
        [SerializeField] private RectTransform dragRectTransform;
        [SerializeField] private Canvas _canvas;
        private float _timeBetweenShoot=0.1f;
        private bool _shooting;
        public GameObject BulletPrfub;
        public Transform PointToShoot;
        public GameObject MoveTarget;
        private bool _isMoving;
        private Vector3 _hitPoint;
        private PlayerRotator _playerRotator;
        [SerializeField]private LayerMask _plaLayerMask;
        public bool CanAtack = true;
        public Weapon myWeapon;
        public GameObject RestartButton;
        private void Awake()
        {
            _playerRotator = FindObjectOfType<PlayerRotator>();
            myWeapon = FindObjectOfType<Weapon>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragRectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(dragRectTransform.position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _hitPoint = hit.point;
            }

            if (Input.GetMouseButton(0))
            {
                if (CanAtack)
                {
                    if (!_shooting)
                    {
                        _playerRotator.Speed = -0.1f;
                        StartCoroutine(Shooting());
                    }
                }
                
            }

            if (Input.GetMouseButtonUp(0))
            {
                _playerRotator.Speed = -0.3f;
                _shooting = false;
            }
        }

        private IEnumerator Shooting()
        {
            _shooting = true;
            while (_shooting&&CanAtack)
            {
                yield return new WaitForSecondsRealtime(_timeBetweenShoot);
                if (BulletPrfub != null)
                {
                   // GameObject bullet = Instantiate(BulletPrfub, PointToShoot.position, Quaternion.identity);
                    Vector3 shootVector =(_hitPoint-PointToShoot.position);
                    float distance = shootVector.magnitude;
                    Vector3 direction = shootVector / distance;
                   // Debug.DrawRay(PointToShoot.position, direction, Color.green);
                   // bullet.GetComponent<Rigidbody>().AddForce(direction*50,ForceMode.Impulse);
                   myWeapon.ShootBullet(direction);
                }
                
            
            }
        
        }

        public void MoveUp()
        {
            if (_isMoving||MoveTarget == null) return;
            Vector3 vectorToMove = MoveTarget.transform.position + new Vector3(0, 9, 0);
           StartCoroutine(Move(vectorToMove));
        }

        public void MoveDown()
        {
            if (_isMoving||MoveTarget == null) return;
            Vector3 vectorToMove = MoveTarget.transform.position + new Vector3(0, -9, 0);
            StartCoroutine(Move(vectorToMove));
        }

        private IEnumerator Move(Vector3 value)
        {
            
            if (MoveTarget == null) yield break;
            _isMoving = true;
            float t = 0;
            while (MoveTarget.transform.position!=value)
            {
                t += 0.01f * Time.deltaTime;
                MoveTarget.transform.position = Vector3.Lerp(MoveTarget.transform.position, value, t);
                yield return null;
            }

            _isMoving = false;

        }

        public void Restart()
        {
            RestartButton.SetActive(true);
        }
    }
}
