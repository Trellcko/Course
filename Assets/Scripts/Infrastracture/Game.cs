using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class Game
    {
        public static IInputService InputSerivce;

        public Game()
        {
            RegisterInput();
        }

        private static void RegisterInput()
        {
            if (Application.isEditor)
            {
                InputSerivce = new StandaloneInputService();
            }
            else
            {
                InputSerivce = new MobileInputServie();
            }
        }
    }
}