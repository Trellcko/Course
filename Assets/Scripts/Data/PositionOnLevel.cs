namespace CodeBase.Data
{
    public class PositionOnLevel
    {
        public Vector3Data Vector3Data { get; private set; }
        public string Level { get; private set; }

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