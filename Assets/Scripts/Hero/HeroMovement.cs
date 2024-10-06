using CodeBase.Infastructure;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;

        private Camera _camera;

        private void Awake()
        {
            _inputService = Game.InputSerivce;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 axis = _inputService.Axis;
            Vector3 movement = Vector3.zero;

            if(axis.sqrMagnitude > Constants.Epsilon)
            {
                movement = _camera.transform.TransformDirection(axis);
                movement.y = 0;
                movement.Normalize();

                transform.forward = movement;
            }

            movement += Physics.gravity;

            _characterController.Move(movement * Time.deltaTime * _movementSpeed);
        }
    }
}
