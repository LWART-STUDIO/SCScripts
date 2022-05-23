using System;

namespace GAME_MAIN.CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        
        public PositionOnLevel PositionOnLevel;

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel);
        }
    }
}