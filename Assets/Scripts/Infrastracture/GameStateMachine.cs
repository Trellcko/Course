using System;
using System.Collections.Generic;

namespace CodeBase.Infastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _state;
        private IState _activeState;

        public GameStateMachine() 
        {
            _state = new()
            {
                {typeof(BootstrapState), new BootstrapState(this) }
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _state[typeof(TState)];
            state.Enter();
            _activeState = state;
        }

    }
}
