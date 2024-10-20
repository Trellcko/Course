using UnityEngine;

namespace CodeBase.Infastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject initialPoint);
        void CreateHub();
    }
}