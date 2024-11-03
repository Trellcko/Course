using CodeBase.Infastructure;
using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class AgentRotatingToHero : AgentFollowing
    {
        [SerializeField] private float _speed;

        private Transform _heroTransform;
        private IGameFactory _gameFactory;
        private Vector3 _lookAtPosition;

        private float _speedFactor => _speed * Time.deltaTime;

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

        private void Update()
        {
            if (_heroTransform)
            {
                RotateToHero();
            }
        }

        private void OnHeroCreated()
        {
            _heroTransform = _gameFactory.Hero.transform;
        }

        private void RotateToHero()
        {
            UpdatePositionToLookAt();

            transform.rotation = SmoothRotation(transform.rotation, _lookAtPosition);
        }

        private Quaternion SmoothRotation(Quaternion rotation, Vector3 lookAtPosition) 
            => Quaternion.Lerp(rotation, GetTargetRotation(lookAtPosition), _speedFactor);

        private Quaternion GetTargetRotation(Vector3 lookAtPosition) 
            => Quaternion.LookRotation(lookAtPosition);

        private void UpdatePositionToLookAt()
        {
            _lookAtPosition = _heroTransform.position - transform.position;

            _lookAtPosition.y = _heroTransform.position.y;
        }
    }
}
