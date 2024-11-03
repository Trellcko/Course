using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAnimator : MonoBehaviour, IAnimatorStateReader
    {
        [SerializeField] private Animator _animator;

        private readonly int _dieHash = Animator.StringToHash("Die");
        private readonly int _speedHash = Animator.StringToHash("Speed");

        private readonly int _dieStateHash = Animator.StringToHash("Die02_SwordAndShield");

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
    }
}