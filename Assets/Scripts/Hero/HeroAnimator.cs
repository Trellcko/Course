using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CodeBase
{
    public class HeroAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        
        private readonly int _speedHash = Animator.StringToHash("Speed");
        private readonly int _dieHash = Animator.StringToHash("Die");
        private readonly int _attackingStateHash = Animator.StringToHash("Attack01_SwordAndShiled"); 
        private readonly int _attackHash = Animator.StringToHash("Attack");
        
        public event Action Attacked;
        public event Action AttackEnded;

        public bool IsAttackingState => _animator.GetCurrentAnimatorStateInfo(0).fullPathHash == _attackingStateHash;

        private void Update()
        {
            SetSpeed(_characterController.velocity.magnitude);
        }

        public void OnAttackEnded()
        {

        }
        public void OnAttack()
        {
            Attacked?.Invoke();
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(_attackHash);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(_dieHash);
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(_speedHash, speed, 0.1f, Time.deltaTime);
        }
    }
}
