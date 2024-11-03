using CodeBase.GameLogic.UILogic;
using UnityEngine;

namespace CodeBase.Infastructure
{

    public class GameBootstraper : MonoBehaviour, ICorountineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtainPrefab;

        private Game _game;
        
        private void Awake()
        {
            LoadingCurtain loadingCurtain = Instantiate(_loadingCurtainPrefab);

            _game = new Game(this, loadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _game.StateMachine.Update();
        }

    }
}