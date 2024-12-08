using CodeBase.Infastructure;
using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class AgentRotatingToHero : AgentFollowing
    {
        [SerializeField] private float _speed;

        private Vector3 _lookAtPosition;

        private float _speedFactor => _speed * Time.deltaTime;

        private void Update()
        {
            if (Target)
            {
                RotateToHero();
            }
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
            _lookAtPosition = Target.position - transform.position;

            _lookAtPosition.y = Target.position.y;
        }
    }
}
