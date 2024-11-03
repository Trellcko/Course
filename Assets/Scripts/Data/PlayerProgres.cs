namespace CodeBase.Data
{
    public class PlayerProgres
    {
        public PlayerProgres(string levelName)
        {
            WorldData = new WorldData(levelName);
        }

        public WorldData WorldData;
    }
}
