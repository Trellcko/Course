using CodeBase.GameLogic;
using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "SO/MonsterData")]
    public class MonsterStaticData : ScriptableObject
    {
        [field: SerializeField] public EnemyTypeId EnemyTypeId;
        [field: SerializeField] public float MoveSpeed { get; internal set; }
        [field: Range(1, 100)]
        [field: SerializeField] public int HP { get; private set; }
        [field: SerializeField] public Vector2Int MinMaxLoot { get; private set; }

        [field: Range(1f, 30f)]
        [field: SerializeField] public int Damage { get; private set; }
        [field: Range(0.5f, 1f)]
        [field: SerializeField] public float EffectiveDistance { get; private set; }
        [field: Range(0.5f, 1f)]
        [field: SerializeField] public float CoolDown { get; private set; }
        [field: Range(0.5f, 1f)]
        [field: SerializeField] public float Cleavage { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
