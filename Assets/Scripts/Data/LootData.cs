using System;

namespace CodeBase.Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;

        public event Action Changed;
        internal void Collect(Loot loot)
        {
            Collected = loot.Value;
            Changed?.Invoke();
        }
    }
}