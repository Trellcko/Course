namespace CodeBase.Data
{
    public class PlayerProgres
    {
        public WorldData WorldData;
        public StateHP HeroStateHP;
        public Stats HeroStats;
        public KillsData KillsData;

        public PlayerProgres(string levelName)
        {
            WorldData = new(levelName);
            HeroStateHP = new();
            HeroStats = new();
            KillsData = new();
        }
    }
}
