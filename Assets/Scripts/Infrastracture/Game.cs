using CodeBase.GameLogic.UILogic;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICorountineRunner corountineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new(new SceneLoader(corountineRunner), loadingCurtain, ServiceLocator.Instance);
        }

    }
}