using CodeBase.Data;
using CodeBase.GameLogic;
using CodeBase.Infastructure;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, MonsterStaticData> _monsters;

        public void LoadMonsters()
        {
            _monsters = Resources.LoadAll<MonsterStaticData>(AssetPath.StaticDataFolderPath)
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }

        public MonsterStaticData ForMonster(EnemyTypeId enemyTypeId) =>
            _monsters.TryGetValue(enemyTypeId, out MonsterStaticData monster) ? monster : null;
    }
}
