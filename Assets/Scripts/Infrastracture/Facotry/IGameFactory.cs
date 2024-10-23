using CodeBase.Hero;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public interface IGameFactory : IService
    {
        IReadOnlyList<IReadProgress> ReadProgresses { get; }
        IReadOnlyList<ISaveProgress> SaveProgresses { get; }

        void CleanUp();
        GameObject CreateHero(GameObject initialPoint);
        void CreateHub();
    }
}