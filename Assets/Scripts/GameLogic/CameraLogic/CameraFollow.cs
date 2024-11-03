using UnityEngine;

namespace CodeBase.GameLogic.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _follow;
        
        [SerializeField] private float _rotationAngelX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private void LateUpdate()
        {
            if (!_follow)
                return;
            Vector3 followingPosition = CalculateFollowingPointPosition();

            Quaternion rotation = Quaternion.Euler(_rotationAngelX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + followingPosition;
            transform.SetPositionAndRotation(position, rotation);
        }

        public void SetFollowTarget(Transform follow)
        {
            _follow = follow;
        }

        private Vector3 CalculateFollowingPointPosition()
        {
            Vector3 followingPosition = _follow.position;
            followingPosition.y += _offsetY;

            return followingPosition;
        }
    }
}
