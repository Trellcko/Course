using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.GameLogic.UILogic
{
    public class ActorUI : MonoBehaviour 
    {
        [SerializeField] private HPBar _hpBar;

        private HeroHealth _heroHealth;

        public void Construct(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.HealthChange += UpdateBar;
        }

        private void OnDestroy() => 
            _heroHealth.HealthChange -= UpdateBar;

        private void UpdateBar() => 
            _hpBar.SetValue(_heroHealth.Max, _heroHealth.Current);
    }
}
