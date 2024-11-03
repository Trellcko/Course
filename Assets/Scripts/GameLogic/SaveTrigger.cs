using CodeBase.Infastructure;
using UnityEngine;

namespace CodeBase.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;

        private ISaveLoadProgresService _saveLoadService;
        
        private void Awake()
        {
            _saveLoadService = ServiceLocator.Instance.Single<ISaveLoadProgresService>();
        }

        private void OnDrawGizmosSelected()
        {
            if (!_collider)
                return;

            Gizmos.color = new Color32(30, 200, 30, 120);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);    
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgres();
            Debug.Log("Saved");
            gameObject.SetActive(false);
        }
    }
}
