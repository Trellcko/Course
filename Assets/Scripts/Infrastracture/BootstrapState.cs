using CodeBase.Services.Input;
using System;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class BootstrapState : IState
    {
        private GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            RegisterServices();
        }

        public void Exit()
        {
        }


        private void RegisterServices()
        {
            Game.InputSerivce = RegisterInput();
        }

        private static IInputService RegisterInput()
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
