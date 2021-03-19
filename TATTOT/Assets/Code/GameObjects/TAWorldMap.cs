using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TAWorldMap : MonoBehaviour
{
    #region Unity Game objects

    public Tilemap tilemap;

    #endregion

    #region TA Game objects

    public TAConfiguration configuration;

    /// <summary>
    /// World data stored along the main <see cref="Tilemap"/>.
    /// Each entry is a <see cref="TATerrain"/> instance, with its own parameters.
    /// </summary>
    public IDictionary<Vector3Int, TATerrain> world;

    #endregion

    #region MonoBehaviour implementation

    void Start()
    {
        this.GenerateWorld();
        this.GeneratePlayerStart();
    }

    #endregion

    #region World creation

    /// <summary>
    /// Generate a new <see cref="TAWorldMap"/> using the <see cref="TAWorldFactory"/>.
    ///
    /// TODO: Later on, this process should use a seed.
    /// 
    /// </summary>
    void GenerateWorld()
    {
        /// 1. Load the new world data using <see cref="TAWorldFactory"/>
        IDictionary<Vector3Int, TATerrain> terrainMatrix = TAWorldFactory.BuildWithSize(TAConfigurationLoader.GetConfiguration().WorldMapSize());

        /// 2. Clear the <see cref="Tilemap"/>
        this.tilemap.ClearAllTiles();

        /// 3. Load each <see cref="Tile"/> using <see cref="TATerrain"/> data.
        foreach(KeyValuePair<Vector3Int, TATerrain> terrainData in terrainMatrix)
        { 
            this.tilemap.SetTile(terrainData.Key, TATileLoader.LoadTileFromTerrain(terrainData.Value));
        }

        /// 4. Store the <see cref="TATerrain"/> data along the <see cref="Tilemap"/>
        this.world = terrainMatrix;
    }

    /// <summary>
    /// Generate the player start position.
    /// </summary>
    void GeneratePlayerStart()
    {
        Vector2Int worldSize = TAConfigurationLoader.GetConfiguration().WorldMapSize();
        Vector3Int playerPosition = TAWorldFactory.BuildPlayerStartPosition(worldSize);

        this.tilemap.SetTile(playerPosition, TATileLoader.LoadPlayerStartTile());
    }

    #endregion
}
