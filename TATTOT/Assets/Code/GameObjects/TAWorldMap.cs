using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TAWorldMap : MonoBehaviour
{
    public Tilemap tilemap;

    // STATIC VARS USED FOR DEBUGGING AND DEVELOPMENT
    // TODO: Move this to a ressource file
    private Vector2Int worldSize = new Vector2Int(45, 45);

    // Start is called before the first frame update
    void Start()
    {
        this.GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region World creation

    /// <summary>
    /// Generate a new <see cref="TAWorldMap"/> using the <see cref="TAWorldFactory"/>.
    ///
    /// TODO: Later on, this process should use a seed.
    /// 
    /// 1. Ask for the <see cref="TAWorldFactory"/> for a new build.
    /// 2. Store the <see cref="TATerrain"/> from the new generated build.
    /// 3. Sync the <see cref="Tilemap"/> with the <see cref="TATerrain"/> stored.
    /// </summary>
    void GenerateWorld()
    {
        /// 1. Load the new world data using <see cref="TAWorldFactory"/>
        IDictionary<Vector3Int, TATerrain> terrainMatrix = TAWorldFactory.BuildWithSize(this.worldSize);

        /// 2. Clear the <see cref="Tilemap"/>
        //this.tilemap.ClearAllTiles();

        /// 3. Load each <see cref="Tile"/> using <see cref="TATerrain"/> data.
        foreach(KeyValuePair<Vector3Int, TATerrain> terrainData in terrainMatrix)
        { 
            this.tilemap.SetTile(terrainData.Key, TATileLoader.LoadTileFromTerrain(terrainData.Value));
        }
    }

    #endregion
}
