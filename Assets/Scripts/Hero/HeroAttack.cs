using CodeBase.Data;
using CodeBase.GameLogic;
using CodeBase.Infastructure;
using CodeBase.Services.Input;
using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAttack : MonoBehaviour, IReadProgress
    {
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private CharacterController _characterController;

        public event Action Attacked;
        public event Action AttackEnded;

        private IInputService _input;
        private int _layerMask;
        private Collider[] _colliders = new Collider[5];
        private Stats _stats;

        private float _damage => _stats.Damage;
        private float _radius => _stats.Radius;

        private void Awake()
        {     
            _input = ServiceLocator.Instance.Single<IInputService>();
            _layerMask = 1 << LayerMask.NameToLayer("Hittable");
        }

        private void OnEnable()
        {
            _animator.Attacked += OnAttacked;
        }

        private void OnDisable()
        {
            _animator.Attacked -= OnAttacked;
        }


        private void Update()
        {
            if (_input.IsAttackButtonUp && !_animator.IsAttackingState)
            {
                _animator.PlayAttack();
            }
        }
        private void OnAttacked()
        {
            int count = Hit();

            for(int  i = 0; i < count; i++)
            {
                if(_colliders[i].transform.parent.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_damage);
                }
            }
        }

        private int Hit() => 
            Physics.OverlapSphereNonAlloc(GetStartPoint() + transform.forward, _radius, _colliders, _layerMask);

        private Vector3 GetStartPoint()
            => new Vector3(transform.position.x, _characterController.center.y / 2, transform.position.z);

        public void LoadProgress(PlayerProgres playerProgres)
        {
            _stats = playerProgres.HeroStats;
        }
    }
}
