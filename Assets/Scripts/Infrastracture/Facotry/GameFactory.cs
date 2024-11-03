using CodeBase.Hero;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace CodeBase.Infastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public IReadOnlyList<ISaveProgress> SaveProgresses => _saveProgresses;
        public IReadOnlyList<IReadProgress> ReadProgresses => _readProgresses;

        public GameObject Hero { get; private set; }

        private List<ISaveProgress> _saveProgresses = new();
        private List<IReadProgress> _readProgresses = new();

        public event Action HeroCreated;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            Hero = InstatiateRegister(AssetPath.HetoPrefabPath, initialPoint.transform.position);
            HeroCreated?.Invoke();
            return Hero;
        }

        public void CreateHub() =>
            InstatiateRegister(AssetPath.HudPrefabPath);

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
        private void Register(IReadProgress saveProgress)
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
    }
}
