using System;

namespace CodeBase.Data
{
    [Serializable]
    public class StateHP
    {
        public float Current;
        public float Max;

        public void Reset()
            => Current = Max;
    }
}
