using CodeBase.Data;
using CodeBase.Infastructure;

namespace CodeBase.Infrastracture.PersistanceProgress
{
    public interface IPersistanceProgresService : IService
    {
        PlayerProgres PlayerProgress { get; set; }
    }
}