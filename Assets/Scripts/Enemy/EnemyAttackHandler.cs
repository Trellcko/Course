using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAttackHandler : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;

            _enemyAttack.DisableAttack();
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerExit -= TriggerExit;
            _triggerObserver.TriggerEnter -= TriggerEnter;
        }

        private void TriggerExit(Collider obj)
        {
            _enemyAttack.DisableAttack();
        }

        private void TriggerEnter(Collider obj)
        {
            _enemyAttack.EnableAttack();
        }
    }
}
