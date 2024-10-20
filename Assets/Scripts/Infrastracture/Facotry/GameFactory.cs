using System;
using UnityEngine;
namespace CodeBase.Infastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject initialPoint) => 
            _assets.Instantiate(AssetPath.HetoPrefabPath, initialPoint.transform.position);
        public void CreateHub() => 
            _assets.Instantiate(AssetPath.HudPrefabPath);
    }
}
