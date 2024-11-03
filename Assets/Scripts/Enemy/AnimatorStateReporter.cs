using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase
{
    public class AnimatorStateReporter : StateMachineBehaviour
    {
        private IAnimatorStateReader _stateReader;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            if (TryGetReader(animator, out IAnimatorStateReader reader))
            {
                reader.EnterState(stateInfo.shortNameHash);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);

            if (TryGetReader(animator, out IAnimatorStateReader reader))
            {
                reader.EnterState(stateInfo.shortNameHash);
            }
        }

        private bool TryGetReader(Animator animator, out IAnimatorStateReader reader)
        {
            if (_stateReader != null)
            {
                reader = _stateReader;
                return true;
            }

            if(animator.TryGetComponent(out reader))
            {
                _stateReader = reader;
                return true;
            }
            return false;
        }
    }
}
