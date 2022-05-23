using System.Linq;
using GAME_MAIN.CodeBase.Logic;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Enemy
{
  [RequireComponent(typeof(EnemyAnimator))]
    public class Attack: MonoBehaviour
    {
        public EnemyAnimator Animator;

    public float AttackCooldown = 3.0f;
    public float Cleavage = 0.5f;
    public float EffectiveDistance = 0.5f;
    public float Damage = 10;
    
    private Transform _heroTransform;
    private float _attackCooldown;
    private bool _isAttacking;
    private Collider[] _hits = new Collider[1];
    private int _layerMAsk;

    private bool _attackIsActive;
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private GameObject _restartButton;
    
    
    public void Constract(Transform heroTransform)
    {
      _heroTransform = heroTransform;
    }
    

    private void Awake()
    {

      _layerMAsk = 1 << LayerMask.NameToLayer("Player");
      
    }

    public void Restart()
    {
      _restartButton.SetActive(true);
    }

    private void Update()
    {
      UpdateCooldown();

      //if(CanAttack())
      //  StartAttack();
    }

    private void OnAttack()
    {
      _enemyWeapon.Shoot();
      if (Hit(out Collider hit))
      {
        //PhysicsDebug.DrawDebug(StartPoint(), Cleavage, 1.0f);
        hit.transform.GetComponent<IHealth>().TakeDamage(Damage);
      }
    }

    private void OnAttackEnded()
    {
      _attackCooldown = AttackCooldown;
      _isAttacking = false;
    }

    public void DisableAttack()
    {
      _attackIsActive = false;
      Animator.PlayIdle();
    }

    public void EnableAttack()
    {
      _attackIsActive = true;
    }
    

    private bool CooldownIsUp()
    {
      return _attackCooldown <= 0f;
    }

    private void UpdateCooldown()
    {
      if (!CooldownIsUp())
        _attackCooldown -= Time.deltaTime;
    }

    private bool Hit(out Collider hit)
    {
      var hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), Cleavage, _hits, _layerMAsk);

      hit = _hits.FirstOrDefault();
      
      return hitAmount > 0;
    }

    private Vector3 StartPoint()
    {
      return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
             transform.forward * EffectiveDistance;
    }

    private bool CanAttack()
    {
      return _attackIsActive && !_isAttacking;
    }

    public void StartAttack()
    {
      
      transform.LookAt(_heroTransform);
      Animator.PlayAttack();
      EnableAttack();
    }
    }
}