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
        }

        public PositionOnLevel PositionOnLevel;
    }
}