using CodeBase.Data;
using CodeBase.GameLogic;
using CodeBase.Infastructure;

namespace CodeBase.Services
{
    public interface IStaticDataService : IService
    {
        MonsterStaticData ForMonster(EnemyTypeId enemyTypeId);
        void LoadMonsters();
    }
}