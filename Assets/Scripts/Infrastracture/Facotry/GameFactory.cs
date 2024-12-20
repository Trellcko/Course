﻿using CodeBase.Data;
using CodeBase.Enemy;
using CodeBase.GameLogic;
using CodeBase.GameLogic.UILogic;
using CodeBase.Hero;
using CodeBase.Infrastracture.PersistanceProgress;
using CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Infastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistanceProgresService _persistenceProgressService;

        public IReadOnlyList<ISaveProgress> SaveProgresses => _saveProgresses;
        public IReadOnlyList<IReadProgress> ReadProgresses => _readProgresses;

        public GameObject Hero { get; private set; }

        private List<ISaveProgress> _saveProgresses = new();
        private List<IReadProgress> _readProgresses = new();

        public GameFactory(IAssetProvider assets, IStaticDataService staticDataService, IPersistanceProgresService persistanceProgresService)
        {
            _assets = assets;
            _staticDataService = staticDataService;
            _persistenceProgressService = persistanceProgresService;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            Hero = InstatiateRegister(AssetPath.HetoPrefabPath, initialPoint.transform.position);
            return Hero;
        }

        public GameObject CreateHub()
        {
            GameObject hub = InstatiateRegister(AssetPath.HudPrefabPath);
            hub.GetComponent<LootCounter>().Constrcut(_persistenceProgressService.PlayerProgress.WorldData);

            return hub;
        }
        public GameObject CreateMonster(EnemyTypeId enemyId, Transform transform)
        {
           MonsterStaticData data = _staticDataService.ForMonster(enemyId);
           GameObject monster = UnityEngine.Object.Instantiate(data.Prefab, transform.position, Quaternion.identity, transform);

            IHealth health = monster.GetComponent<IHealth>();
            health.ForceSet(data.HP);
            
            monster.GetComponentInChildren<ActorUI>().Construct(health);
            monster.GetComponent<AgentFollowing>().Construct(Hero.transform);
            monster.GetComponent<NavMeshAgent>().speed = data.MoveSpeed;
            LootSpawner lootSpawner = monster.GetComponentInChildren<LootSpawner>();
            lootSpawner.Construct(this);
            lootSpawner.SetValue(data.MinMaxLoot);
            EnemyAttack enemyAttack = monster.GetComponent<EnemyAttack>();
            enemyAttack.Construct(Hero.transform, data.Damage, data.EffectiveDistance, data.Cleavage, data.CoolDown);
            return monster;
        }
        private GameObject InstatiateRegister(string path, Vector3 position)
        {
            GameObject spawned = _assets.Instantiate(path, position);
            RegisterProgress(spawned);
            return spawned;
        }

        private GameObject InstatiateRegister(string path)
        {
            GameObject spawned = _assets.Instantiate(path);
            RegisterProgress(spawned);
            return spawned;
        }

        private void RegisterProgress(GameObject gameObject)
        {
            foreach (var saveProgress in gameObject.GetComponentsInChildren<IReadProgress>())
            {
                Register(saveProgress);
            }
        }

        public void Register(IReadProgress saveProgress)
        {
            if(saveProgress is ISaveProgress progresWriter)
            {
                _saveProgresses.Add(progresWriter);
            }
            _readProgresses.Add(saveProgress);
        }
        public void CleanUp()
        {
            _saveProgresses.Clear();
            _readProgresses.Clear();
        }

        public LootPiece CreateLoot()
        {
            LootPiece lootPiece = InstatiateRegister(AssetPath.LootPrefabPath).GetComponent<LootPiece>();

            lootPiece.Construct(_persistenceProgressService.PlayerProgress.WorldData);
            
            return lootPiece;
        }
    }
}
