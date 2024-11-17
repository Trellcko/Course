using System;

namespace CodeBase.GameLogic
{
    public interface IHealth
    {
        float Current { get; }
        float Max { get; }

        event Action Changed;

        void TakeDamage(float damage);
    }
}