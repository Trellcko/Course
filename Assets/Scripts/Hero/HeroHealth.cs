using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroHealth : MonoBehaviour, ISaveProgress
    {
        [SerializeField] private HeroAnimator _heroAnimator;

        private StateHP _heroStateHP;

        public float Max => _heroStateHP.Max;
        public float Current
        {
            get => _heroStateHP.Current;
            set => _heroStateHP.Current = value;
        }

        public void LoadProgress(PlayerProgres playerProgres)
        {
            _heroStateHP = playerProgres.HeroStateHP;
        }

        public void UpdateProgress(PlayerProgres playerProgres)
        {
            
        }

        public void TakeDamage(float damage)
        {
            if (Current < 0)
                return;
            

            Current-=damage;

            if (Current < 0)
                _heroAnimator.PlayDeath();
        }
    }
}
