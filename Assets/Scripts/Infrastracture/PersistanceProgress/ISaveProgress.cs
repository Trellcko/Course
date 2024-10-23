using CodeBase.Data;

namespace CodeBase.Hero
{
    public interface ISaveProgress : IReadProgress
    {
        void UpdateProgress(PlayerProgres playerProgres);
    }
}
