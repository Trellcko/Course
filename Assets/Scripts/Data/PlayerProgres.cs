namespace CodeBase.Data
{
    public class PlayerProgres
    {
        public WorldData WorldData;
        public StateHP HeroStateHP;

        public PlayerProgres(string levelName)
        {
            WorldData = new WorldData(levelName);
            HeroStateHP = new StateHP();
        }

    }
}
