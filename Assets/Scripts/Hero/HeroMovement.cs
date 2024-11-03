using CodeBase.Data;
using CodeBase.Infastructure;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Hero
{
    public class HeroMovement : MonoBehaviour, ISaveProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;

        private Camera _camera;


        private void Awake()
        {
            _inputService = ServiceLocator.Instance.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 axis = _inputService.Axis;
            Vector3 movement = Vector3.zero;

            if (axis.sqrMagnitude > Constants.Epsilon)
            {
                movement = _camera.transform.TransformDirection(axis);
                movement.y = 0;
                movement.Normalize();

                transform.forward = movement;
            }

            movement += Physics.gravity;

            _characterController.Move(movement * Time.deltaTime * _movementSpeed);
        }
        public void LoadProgress(PlayerProgres playerProgres)
        {

            if (SceneManager.GetActiveScene().name == playerProgres.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = playerProgres.WorldData.PositionOnLevel.Vector3Data;
                if (savedPosition != null)
                {
                    Vector3 position = savedPosition.AsUnityVector();
                    WarpTo(position);
                }
            }
        }

        public void UpdateProgress(PlayerProgres playerProgres)
        {
            playerProgres.WorldData.PositionOnLevel = 
                new(SceneManager.GetActiveScene().name, transform.position.AsVectorData());
        }

        private void WarpTo(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position.AddY(_characterController.height);
            _characterController.enabled = true;
        }
    }
}
