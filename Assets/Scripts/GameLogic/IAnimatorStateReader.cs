using UnityEditor.Animations;

namespace CodeBase.Enemy
{
    public interface IAnimatorStateReader
    {
        void EnterState(int hash);

        void ExitState(int hash);

        AnimatorStateName State { get; }
    }

    public enum AnimatorStateName
    {
        Idle,
        Die,
    }
}
