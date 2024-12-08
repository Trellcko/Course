using CodeBase.Data;
using CodeBase.Enemy;
using CodeBase.Hero;
using CodeBase.Infastructure;
using UnityEngine;

namespace CodeBase.GameLogic
{
    public class EnemySpawner : MonoBehaviour, ISaveProgress
    {
        [SerializeField] private EnemyTypeId _enemyId;
        [SerializeField] private UniqueId _id;

         private bool _slain;
        private IGameFactory _factory;
        private EnemyDeath _enemyDeath;

        private void Awake()
        {
            _factory = ServiceLocator.Instance.Single<IGameFactory>();
        }

        private void OnDestroy()
        {
            if(_enemyDeath)
            _enemyDeath.DeathHappened -= Slay;
        }

        public void LoadProgress(PlayerProgres playerProgres)
        {
            if (playerProgres.KillsData.ClearSpawners.Contains(_id.Id))
            {
                _slain = true;
            }
            else
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            GameObject monster = _factory.CreateMonster(_enemyId, transform);
            _enemyDeath = monster.GetComponent<EnemyDeath>();
            _enemyDeath.DeathHappened += Slay;
            
            Debug.Log($"SPAWN: {_enemyId}");
        }

        private void Slay()
        {
            _enemyDeath.DeathHappened -= Slay;
            _slain = true;
        }

        public void UpdateProgress(PlayerProgres playerProgres)
        {
            if(_slain)
            {
                playerProgres.KillsData.ClearSpawners.Add(_id.Id);
            }
        }
    }
}
