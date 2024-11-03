using CodeBase.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase
{
    public class AnimatorAlong : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _animator;

        private void Update()
        {
            _animator.SetSpeed(_navMeshAgent.velocity.magnitude);
        }
    }
}
