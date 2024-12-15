using CodeBase.Data;
using TMPro;
using UnityEngine;

namespace CodeBase.GameLogic.UILogic
{
    public class LootCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;

        private WorldData _worldData;

        private void Start()
        {
            UpdateCounter();
        }

        public void Constrcut(WorldData worldData)
        {
            _worldData = worldData;
            _worldData.LootData.Changed += UpdateCounter;
        }

        private void UpdateCounter()
        {
            _counter.SetText(_worldData.LootData.Collected.ToString()); 
        }
    }
}
