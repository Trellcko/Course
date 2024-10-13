using CodeBase.Services.Input;
using System;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "Initial";
     
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(InitialSceneName, EnterLoadLevel);
        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadLevelState>();

        public void Exit()
        {
        }


        private void RegisterServices()
        {
            Game.InputSerivce = RegisterInput();
        }

        private IInputService RegisterInput()
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
