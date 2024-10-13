namespace CodeBase.Infastructure
{
    public interface IState : IUpdatableState
    {
        void Enter();
    }

    public interface IPayLoadState<TPayLoad> : IUpdatableState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IUpdatableState : IExitableState
    {
        void Update();
    }

    public interface IExitableState
    {
        void Exit();
    }

}