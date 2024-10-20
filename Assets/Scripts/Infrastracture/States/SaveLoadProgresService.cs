using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class SaveLoadProgresService : ISaveLoadProgresService
    {
        private const string ProgresKey = "Progres";

        public void SaveProgres()
        {

        }

        public PlayerProgres LoadProgres() => 
            PlayerPrefs.GetString(ProgresKey)?.ToDeserialize<PlayerProgres>();
    }
}
