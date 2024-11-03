using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public Vector3Data Vector3Data;
        public string Level;

        public PositionOnLevel(string level, Vector3Data vector3Data)
        {
            Level = level;
            Vector3Data = vector3Data;
        }

        public PositionOnLevel(string level)
        {
            Level = level;
        }
    }
}