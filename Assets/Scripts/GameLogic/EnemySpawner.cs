using CodeBase.Data;
using CodeBase.Hero;
using System;
using UnityEngine;

namespace CodeBase.GameLogic
{
    public class EnemySpawner : MonoBehaviour, ISaveProgress
    {
        [SerializeField] private EnemyTypeId _enemyId;
        [SerializeField] private UniqueId _id;

        [SerializeField] private bool _slain;
        
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
            Debug.Log($"SPAWN: {_enemyId}");
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
