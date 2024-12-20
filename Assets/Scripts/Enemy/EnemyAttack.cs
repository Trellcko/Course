using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Aggro _aggro;
        
        private float _attackCoolDown;
        private float _cleavage;
        private float _effectiveDistance;
        private int _damage;

        private Transform _heroTransform;
        private float _currentCoolDown;
        private bool _isAttacking;
        private int _layerMask;
        private Collider[] _hits = new Collider[1];
        private bool _debugAttack;
        private bool _attackIsActive;
        private const string PlayerLayer = "Player";

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(PlayerLayer);
        }

        private void OnEnable()
        {
            _enemyAnimator.Attacked += OnAttack;
            _enemyAnimator.AttackEnded += OnAttackEnded;
        }

        private void OnDisable()
        {
            _enemyAnimator.Attacked -= OnAttack;
            _enemyAnimator.AttackEnded -= OnAttackEnded;
        }

        private void Update()
        {
            UpdateCooldown();

            if (_attackIsActive && CanAttack())
            {
                StartAttack();
            }
        }
        public void DisableAttack() =>
            _attackIsActive = false;

        public void EnableAttack() => 
            _attackIsActive = true;


        private void OnAttack()
        {
            if(Hit(out Collider hit))
            {
                if (hit.TryGetComponent(out HeroHealth heroHealth))
                {
                    Debug.Log(hit.gameObject.name + " was attacked by " + transform.name);

                    heroHealth.TakeDamage(_damage);
                    _aggro.TryToAggro();
                }
            }
        }

        private bool Hit(out Collider hit)
        {
            int count = Physics.OverlapSphereNonAlloc(GetStartPoint(), _cleavage, _hits, _layerMask);
            hit = _hits[0];
            return count > 0;
        }


        private void OnAttackEnded()
        {
            _currentCoolDown = _attackCoolDown;
            _isAttacking = false;
        }

        private bool CanAttack() => 
            _currentCoolDown < 0 && !_isAttacking;
        private void UpdateCooldown() =>
            _currentCoolDown -= Time.deltaTime;
        private Vector3 GetStartPoint()
        {
            return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) + (transform.forward * _effectiveDistance);
        }

        private void StartAttack()
        {

            Debug.Log("InvokeAttack");
            transform.LookAt(_heroTransform);
            _enemyAnimator.PlayAttack();

            _isAttacking = true;
        }

        public void Construct(Transform transform, int damage, float effectiveDistance, float cleavage, float coolDown)
        {
            _attackCoolDown = coolDown;
            _damage = damage;
            _effectiveDistance = effectiveDistance;
            _cleavage = cleavage;
            _heroTransform = transform;
            Debug.Log(_damage);
        }
    }
}
