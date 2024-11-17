using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private HeroMovement _heroMovement;
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private HeroAttack _heroAttack;

        [SerializeField] private GameObject _vfxPrefab;

        private void OnEnable()
        {
            _heroHealth.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _heroHealth.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if(_heroHealth.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _heroHealth.enabled = false;
            _heroMovement.enabled = false;
            _heroAttack.enabled = false;
            _heroAnimator.PlayDeath();

            Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
        }
    }
}
