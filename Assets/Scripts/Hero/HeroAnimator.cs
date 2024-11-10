using UnityEngine;

namespace CodeBase
{
    public class HeroAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        
        private int _speedHash = Animator.StringToHash("Speed");
        private readonly int _dieHash = Animator.StringToHash("Die");

        private void Update()
        {
            SetSpeed(_characterController.velocity.magnitude);
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
