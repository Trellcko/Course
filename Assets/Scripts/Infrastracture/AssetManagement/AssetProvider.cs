using UnityEngine;

namespace CodeBase.Infastructure
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}