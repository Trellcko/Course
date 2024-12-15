using CodeBase.Enemy;
using CodeBase.GameLogic;
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
        void CleanUp();
        GameObject CreateHero(GameObject initialPoint);
        GameObject CreateMonster(EnemyTypeId enemyId, Transform transform);
        GameObject CreateHub();
        void Register(IReadProgress saveProgress);
        LootPiece CreateLoot();
    }
}