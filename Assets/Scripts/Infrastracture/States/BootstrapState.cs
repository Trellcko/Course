using CodeBase.Infrastracture.PersistanceProgress;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "Initial";
     
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _instance;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ServiceLocator instance)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _instance = instance;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialSceneName, EnterLoadProgresState);
        }

        private void EnterLoadProgresState() => 
            _gameStateMachine.Enter<LoadProgresState>();

        public void Update() { }
        public void Exit() {}


        private void RegisterServices()
        {
            _instance.RegisterSingle(GetInput());
            _instance.RegisterSingle<IPersistanceProgresService>(new PersistanceProgresService());
            _instance.RegisterSingle<IAssetProvider>(new AssetProvider());
            _instance.RegisterSingle<IGameFactory>(
                new GameFactory(_instance.Single<IAssetProvider>()));
            _instance.RegisterSingle<ISaveLoadProgresService>(new SaveLoadProgresService(_instance.Single<IGameFactory>(), 
                _instance.Single<IPersistanceProgresService>()));

        }

        private IInputService GetInput()
        {
            if (Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else
            {
                return new MobileInputServie();
            }
        }

    }
}
