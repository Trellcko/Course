using CodeBase.Data;

namespace CodeBase.Infastructure
{
    public interface ISaveLoadProgresService : IService
    {
        PlayerProgres LoadProgres();
        void SaveProgres();
    }
}