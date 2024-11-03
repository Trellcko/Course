using CodeBase.Infastructure;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMovingToHero : AgentFollowing
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private Transform _heroTransform;

        private IGameFactory _gameFactory;

        private const float MinimalDistance = 1f;

        private void Start()
        {
            _gameFactory = ServiceLocator.Instance.Single<IGameFactory>();

            if (_gameFactory.Hero)
            {
                _heroTransform = _gameFactory.Hero.transform;
            }
            else
            {
                _gameFactory.HeroCreated += OnHeroCreated;
            }
        }

        private void OnHeroCreated()
        {
            _gameFactory.HeroCreated -= OnHeroCreated;
            _heroTransform = _gameFactory.Hero.transform;
        }

        private void Update()
        {
            if (_heroTransform && CheckIsHeroReached())
            {
                _navMeshAgent.destination = _heroTransform.position;
            }
        }

        private bool CheckIsHeroReached() => 
            Vector3.Distance(_heroTransform.position, transform.position) > MinimalDistance;
    }
}
