using System;
using System.Collections.Generic;

namespace CodeBase.Data
{
    [Serializable]
    public class KillsData
    {
        public List<string> ClearSpawners = new();
        public KillsData() 
        {
            ClearSpawners = new();
        }
    }
}
