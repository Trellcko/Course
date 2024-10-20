using CodeBase.Infrastracture.PersistanceProgress;
using CodeBase.UILogic;
using System;
using System.Collections.Generic;

namespace CodeBase.Infastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IUpdatableState> _state;
        private IUpdatableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, ServiceLocator serviceLocator) 
        {
            _state = new()
            {
                {typeof(BootstrapState), new BootstrapState(this, sceneLoader, serviceLocator) },
                {typeof(LoadLevelState), new LoadLevelState(this, sceneLoader, loadingCurtain, 
                serviceLocator.Single<IGameFactory>()) },
                {typeof(LoadProgresState), new LoadProgresState(this, serviceLocator.Single<IPersistanceProgresService>(),
                serviceLocator.Single<ISaveLoadProgresService>()) },
                {typeof(GameLoopState), new GameLoopState(this) },
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
}


        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            IPayLoadState<TPayLoad> state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        public void Update()
        {
            _activeState?.Update();
        }

        private TState ChangeState<TState>() where TState : class, IUpdatableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IUpdatableState
        {
            return _state[typeof(TState)] as TState;
        }
    }
}
