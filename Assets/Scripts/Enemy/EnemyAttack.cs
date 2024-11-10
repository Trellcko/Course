using CodeBase.Enemy;
using CodeBase.Infastructure;
using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private float _attackCoolDown = 3f;
        [SerializeField] private float _cleavage = 5f;
        [SerializeField] private float _effectiveDistance = 0.5f;

        private IGameFactory _gameFactory;
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

            _gameFactory = ServiceLocator.Instance.Single<IGameFactory>();
            _gameFactory.HeroCreated += OnHeroCreated;
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
                Debug.Log(hit.gameObject.name + " was attacked by " + transform.name);
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

        private void OnHeroCreated()
        {
            _heroTransform = _gameFactory.Hero.transform;
            _gameFactory.HeroCreated -= OnHeroCreated;
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

    }
}
