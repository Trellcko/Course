using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMovingToHero : AgentFollowing
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private const float MinimalDistance = 1f;

        private void Update()
        {
            if (Target && CheckIsHeroReached())
            {
                _navMeshAgent.destination = Target.position;
            }
        }

        private bool CheckIsHeroReached() => 
            Vector3.Distance(Target.position, transform.position) > MinimalDistance;
    }
}
