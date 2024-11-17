using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.GameLogic.UILogic
{
    public class ActorUI : MonoBehaviour 
    {
        [SerializeField] private HPBar _hpBar;

        private IHealth _heroHealth;

        public void Construct(IHealth heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.Changed += UpdateBar;
        }

        private void Start()
        {
            if(_heroHealth == null)
            {
                _heroHealth = transform.parent.GetComponent<IHealth>();
                _heroHealth.Changed += UpdateBar;
            }
        }

        private void OnDestroy()
        {
            if(_heroHealth != null)
            _heroHealth.Changed -= UpdateBar;
        }
        private void UpdateBar() => 
            _hpBar.SetValue(_heroHealth.Max, _heroHealth.Current);
    }
}
