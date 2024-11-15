using CodeBase.Hero;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public interface IGameFactory : IService
    {
        IReadOnlyList<IReadProgress> ReadProgresses { get; }
        IReadOnlyList<ISaveProgress> SaveProgresses { get; }
        event Action HeroCreated;
        GameObject Hero { get; }

        void CleanUp();
        GameObject CreateHero(GameObject initialPoint);
        GameObject CreateHub();
    }
}