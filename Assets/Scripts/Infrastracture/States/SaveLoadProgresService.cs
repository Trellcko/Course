using CodeBase.Data;
using CodeBase.Infrastracture.PersistanceProgress;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class SaveLoadProgresService : ISaveLoadProgresService
    {
        private const string ProgresKey = "Progres";

        private readonly IGameFactory _gameFactory;
        private readonly IPersistanceProgresService _persistanceProgresService;

        public SaveLoadProgresService(IGameFactory gameFactory, IPersistanceProgresService persistanceProgresService)
        {
            _gameFactory = gameFactory;
            _persistanceProgresService = persistanceProgresService;
        }

        public void SaveProgres()
        {
            foreach(var progressWriter in _gameFactory.SaveProgresses)
            {
                progressWriter.UpdateProgress(_persistanceProgresService.PlayerProgress);
            }
            PlayerPrefs.SetString(ProgresKey, _persistanceProgresService.PlayerProgress.ToJson());
        }

        public PlayerProgres LoadProgres() => 
            PlayerPrefs.GetString(ProgresKey)?.ToDeserialize<PlayerProgres>();
    }
}
