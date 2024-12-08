using System;

namespace CodeBase.GameLogic
{
    public interface IHealth
    {
        float Current { get; }
        float Max { get; }

        event Action Changed;
        void ForceSet(float health);
        void TakeDamage(float damage);
    }
}