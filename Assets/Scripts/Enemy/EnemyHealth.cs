using CodeBase.GameLogic;
using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private EnemyAnimator _animator;
        [field: SerializeField] public float Max { get; private set; }
        [field: SerializeField] public float Current { get; private set; }

        public event Action Changed;

        public void TakeDamage(float damage)
        {
            Current -= damage;

            Changed?.Invoke();
        }
    }
}
