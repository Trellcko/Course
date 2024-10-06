using UnityEngine;

namespace CodeBase
{
    public class HeroAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        
        private int _speedHash = Animator.StringToHash("Speed");

        private void Update()
        {
            SetSpeed(_characterController.velocity.magnitude);
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(_speedHash, speed, 0.1f, Time.deltaTime);
        }
    }
}
