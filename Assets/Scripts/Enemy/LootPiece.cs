using CodeBase.Data;
using CodeBase.Infastructure;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class LootPiece : MonoBehaviour
    {
        [SerializeField] private GameObject skull;
        [SerializeField] private TextMeshProUGUI lootText;

        private Loot _loot;
        private bool _pick;
        private WorldData _worldData;

        private ISaveLoadProgresService _saveLoadProgresService;

        public void Construct(WorldData worldData, ISaveLoadProgresService saveLoadProgresService)
        {
            _worldData = worldData;
            _saveLoadProgresService = saveLoadProgresService;
        }

        public void Init(Loot loot)
        {
            _loot = loot;
        }

        private void OnTriggerEnter(Collider other) => PickUp();

        private void PickUp()
        {
            if (_pick)
                return;

            _pick = true;


            _worldData.LootData.Collect(_loot);
            ShowText();
            skull.gameObject.SetActive(false);
            _saveLoadProgresService.SaveProgres();

            StartCoroutine(StartDestroyTimer());
        }

        private IEnumerator StartDestroyTimer()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

        private void ShowText()
        {
            lootText.gameObject.SetActive(true);
            lootText.SetText(_loot.Value.ToString());
        }
    }
}
