using CodeBase.Infastructure;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _enemyDeath;
        private IGameFactory _factory;
        private Vector2Int _minMax;

        private void Awake()
        {
            _enemyDeath.DeathHappened += SpawnLoot;
        }

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
        }

        public void SetValue(Vector2Int minMax)
        {
            _minMax = minMax;
        }

        private void SpawnLoot()
        {
            LootPiece loot = _factory.CreateLoot();
            loot.transform.position = transform.position;

            Loot lootData = GenerateLoot();

            loot.Init(lootData);
        }

        private Loot GenerateLoot()
        {
            return new()
            {
                Value = Random.Range(_minMax.x, _minMax.y)
            };
        }
    }
}
