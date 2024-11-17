using CodeBase.Enemy;
using System.Collections;
using UnityEngine;

namespace CodeBase
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _aggroObserver;
        [SerializeField] private AgentFollowing _agentMoveToHero;
        [SerializeField] private float _coolDown;

        private Coroutine _agroCorountine;
        private bool _hasAggroTarget;

        private void Start()
        {
            SwitchFollowOff();
        }

        private void OnEnable()
        {
            _aggroObserver.TriggerEnter += OnAgentTriggerEnter;
            _aggroObserver.TriggerExit += OnAgentTriggerExit;
        }


        private void OnDisable()
        {
            _aggroObserver.TriggerEnter -= OnAgentTriggerEnter;
            _aggroObserver.TriggerExit -= OnAgentTriggerExit;
        }

        private void OnAgentTriggerEnter(Collider obj)
        {
            TryToAggro();
        }

        public bool TryToAggro()
        {
            if (!_hasAggroTarget)
            {
                SwitchFollowOn();

                if (_agroCorountine != null)
                {
                    StopCoroutine(_agroCorountine);
                }

                _agroCorountine = StartCoroutine(SwitchFollowOffAfterCoolDown());
                _hasAggroTarget = true;
                return true;
            }
            return false;
        }

        private IEnumerator SwitchFollowOffAfterCoolDown()
        {
            yield return new WaitForSeconds(_coolDown);
            SwitchFollowOff();
        }

        private void OnAgentTriggerExit(Collider obj)
        {
            if (_hasAggroTarget)
            {
                StopAggroCorountine();
                SwitchFollowOff();
                _hasAggroTarget = false;
            }
        }


        private void SwitchFollowOn() => 
            _agentMoveToHero.enabled = true;

        private void SwitchFollowOff() => 
            _agentMoveToHero.enabled = false;
        private void StopAggroCorountine()
        {
            if (_agroCorountine != null)
            {
                StopCoroutine(_agroCorountine);
                _agroCorountine = null;
            }
        }
    }
}
