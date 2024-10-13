using CodeBase.UILogic;
using UnityEngine;

namespace CodeBase.Infastructure
{

    public class GameBootstraper : MonoBehaviour, ICorountineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, _loadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _game.StateMachine.Update();
        }

    }
}