using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        public GameObject _deathVfx;

        public event Action DeathHappened;

        private void OnEnable()
        {
            _enemyHealth.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _enemyHealth.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_enemyHealth.Current >= 0)
                return;

            Die();
        }

        private void Die()
        {
            _enemyHealth.Changed -= OnHealthChanged;
            _enemyAnimator.PlayDeath();
            
            CreateVFX();

            DeathHappened?.Invoke();
            StartCoroutine(DestroyTimer());
        }

        private void CreateVFX()
        {
            Instantiate(_deathVfx, transform.position, Quaternion.identity);
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}
