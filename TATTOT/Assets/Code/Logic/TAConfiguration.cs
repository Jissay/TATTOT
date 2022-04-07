using System;
using UnityEngine;

namespace Code.Logic
{
    [Serializable]
    public class TAConfiguration
    {
        /* JSON Attributes MUST be public and without any getter / setter */

        #region Game settings

        public int numberOfOpponents;

        #endregion
        
        #region World generation settings
        
        public int worldMapHeight;
        public int worldMapWidth;

        public int opponentMaxReach;
        public int startMapEdgeMaxReach;

        #endregion

        #region Computed vars

        public Vector2Int worldMapSize => new(worldMapWidth, worldMapHeight);

        #endregion
    }
}
