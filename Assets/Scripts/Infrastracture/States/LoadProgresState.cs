using CodeBase.Data;
using CodeBase.Infrastracture.PersistanceProgress;
using System;

namespace CodeBase.Infastructure
{
    public class LoadProgresState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistanceProgresService _persistanceProgresService;
        private readonly ISaveLoadProgresService _saveLoadProgresService;

        public LoadProgresState(GameStateMachine gameStateMachine,
            IPersistanceProgresService persistanceProgresService,
            ISaveLoadProgresService saveLoadProgresService)
        {
            _gameStateMachine = gameStateMachine;
            _persistanceProgresService = persistanceProgresService;
            _saveLoadProgresService = saveLoadProgresService;
        }

        public void Enter()
        {
            _persistanceProgresService.PlayerProgress = _saveLoadProgresService.LoadProgres() ?? InitProgres();

            _gameStateMachine.Enter<LoadLevelState, string>
                (_persistanceProgresService.PlayerProgress.WorldData.PositionOnLevel.Level);
        }


        public void Exit()
        {
        }

        public void Update()
        {
            
        }
        private PlayerProgres InitProgres()
        {
            PlayerProgres progres = new("Main");
            progres.HeroStateHP.Max = 100;
            progres.HeroStateHP.Reset();
            progres.HeroStats.Damage = 1;
            progres.HeroStats.Radius = 0.5f;
            return progres;
        }
    }
}
