using UnityEngine;

namespace CodeBase.GameLogic
{
    public class LookingAtCamera : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Quaternion rotation = _camera.transform.rotation;

            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }
    }
}
