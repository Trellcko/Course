using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAnimator : MonoBehaviour, IAnimatorStateReader
    {
        [SerializeField] private Animator _animator;

        private readonly int _dieHash = Animator.StringToHash("Die");
        private readonly int _speedHash = Animator.StringToHash("Speed");
        private readonly int _attackHash = Animator.StringToHash("Attack");

        private readonly int _dieStateHash = Animator.StringToHash("Die02_SwordAndShield");

        public event Action Attacked;
        public event Action AttackEnded;

        public AnimatorStateName State { get; private set; }

        private void PlayDeath()
        {
            _animator.SetTrigger(_dieHash);
            _animator.SetTrigger(_speedHash);
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(_speedHash, speed);
        }

        public void EnterState(int hash)
        {
            if(hash == _dieStateHash)
            {
                State = AnimatorStateName.Die;
                Debug.Log("Die Enter");
            }
        }

        public void ExitState(int hash)
        {
            if (hash == _dieStateHash)
            {
                Debug.Log("Die Exit");
            }
        }

        public void OnAttackEnded()
        {
            AttackEnded?.Invoke();
        }

        public void OnAttack()
        {
            Attacked?.Invoke();
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(_attackHash);
        }
    }
}
