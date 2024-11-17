using CodeBase.Data;
using CodeBase.GameLogic;
using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroHealth : MonoBehaviour, ISaveProgress, IHealth
    {
        [SerializeField] private HeroAnimator _heroAnimator;

        private StateHP _heroStateHP;

        public event Action Changed;

        public float Max => _heroStateHP.Max;
        public float Current => _heroStateHP.Current;

        public void LoadProgress(PlayerProgres playerProgres)
        {
            _heroStateHP = playerProgres.HeroStateHP;
            Changed?.Invoke();
        }

        public void UpdateProgress(PlayerProgres playerProgres)
        {
            
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"Hero take damage: {damage}");

            if (Current <= 0)
                return;

            _heroStateHP.Current -= damage;
            Changed?.Invoke();

        }
    }
}
