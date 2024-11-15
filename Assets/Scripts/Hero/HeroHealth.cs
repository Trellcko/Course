using CodeBase.Data;
using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroHealth : MonoBehaviour, ISaveProgress
    {
        [SerializeField] private HeroAnimator _heroAnimator;

        private StateHP _heroStateHP;

        public event Action HealthChange;

        public float Max => _heroStateHP.Max;
        public float Current => _heroStateHP.Current;

        public void LoadProgress(PlayerProgres playerProgres)
        {
            _heroStateHP = playerProgres.HeroStateHP;
            HealthChange?.Invoke();
        }

        public void UpdateProgress(PlayerProgres playerProgres)
        {
            
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"Hero take damage: {damage}");

            if (Current < 0)
                return;


            _heroStateHP.Current -= damage;
            HealthChange?.Invoke();

            if (Current < 0)
                _heroAnimator.PlayDeath();
        }
    }
}
