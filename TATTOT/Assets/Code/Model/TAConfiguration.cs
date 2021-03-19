using System;
using UnityEngine;

[Serializable]
public class TAConfiguration
{
    /* JSON Attributes MUST be public and without any getter / setter */

    #region Game settings
    public int worldMapHeight;
    public int worldMapWidth;

    #endregion

    #region Convenience accessors

    public Vector2Int WorldMapSize()
    {
        return new Vector2Int(this.worldMapWidth, this.worldMapHeight);
    }

    #endregion
}
