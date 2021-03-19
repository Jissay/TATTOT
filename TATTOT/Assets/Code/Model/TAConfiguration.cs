using System;
using UnityEngine;

[Serializable]
public class TAConfiguration
{
    /* JSON Attributes MUST be public and without any getter / setter */
    public int worldMapHeight;
    public int worldMapWidth;
    
    public TAConfiguration(int worldMapHeight, int worldMapWidth)
    {
        this.worldMapHeight = worldMapHeight;
        this.worldMapWidth = worldMapWidth;
    }

    public Vector2Int WorldMapSize()
    {
        return new Vector2Int(this.worldMapWidth, this.worldMapHeight);
    }
}
