using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public WorldData(string level)
        {
            PositionOnLevel = new(level);
            LootData = new();
        }

        public PositionOnLevel PositionOnLevel;

        public LootData LootData;
    }
}