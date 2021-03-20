using System;
using UnityEngine;

namespace Code.Model
{
    [Serializable]
    public class TAConfiguration
    {
        /* JSON Attributes MUST be public and without any getter / setter */

        #region Game settings
        
        public int worldMapHeight;
        public int worldMapWidth;

        public int startMapEdgeMaxReach;

        #endregion

        #region Convenience accessors

        public Vector2Int WorldMapSize()
        {
            return new Vector2Int(worldMapWidth, worldMapHeight);
        }

        public int StartMapEdgeMaxReach() { return startMapEdgeMaxReach; }

        #endregion
    }
}
