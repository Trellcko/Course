using UnityEngine;

namespace CodeBase.Infastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstraper prefab;

        private void Awake()
        {
            GameBootstraper gameBootstraper = FindObjectOfType<GameBootstraper>();

            if (gameBootstraper)
                return;

            gameBootstraper = Instantiate(prefab);
        }
    }
}