namespace CodeBase.Infastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}