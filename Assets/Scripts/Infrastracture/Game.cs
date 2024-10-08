using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class Game
    {
        public static IInputService InputSerivce;
        public GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new();
        }

    }
}