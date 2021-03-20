using System.Collections.Generic;
using Code.Events;
using Code.Factories;
using Code.GameObjects;
using Code.Loaders;
using Code.Model.Terrain;
using UnityEngine;

namespace Code.Managers
{
    public class TAWorldManager : TAAbstractManager<TAWorldManager>
    {
        public TAWorldMap worldMap;

        private IDictionary<Vector3Int, TATerrain> _worldData;
        
        #region MonoBehaviour implementation

        private void Start()
        {
            TAEventManager.Shared().CreateWorldEvent.AddListener(CreateWorld);
        }

        #endregion

        #region World creation

        private void CreateWorld()
        {
            GenerateWorld();
            GeneratePlayerStart();
        }
        
        /// <summary>
        /// Generate a new <see cref="TAWorldMap"/> using the <see cref="TAWorldFactory"/>.
        ///
        /// TODO: Later on, this process should use a seed.
        /// 
        /// </summary>
        private void GenerateWorld()
        {
            // 1. Load the new world data using <see cref="TAWorldFactory"/>
            var terrainMatrix = TAWorldFactory.BuildWithSize(TAConfigurationLoader.GetConfiguration().WorldMapSize());

            // 2. Clear the <see cref="Tilemap"/>
            worldMap.tilemap.ClearAllTiles();

            // 3. Load each <see cref="Tile"/> using <see cref="TATerrain"/> data.
            foreach(var terrainData in terrainMatrix)
            { 
                worldMap.tilemap.SetTile(terrainData.Key, TATileLoader.LoadTileFromTerrain(terrainData.Value));
            }

            // 4. Store the <see cref="TATerrain"/> data along the <see cref="Tilemap"/>
            _worldData = terrainMatrix;
        }

        /// <summary>
        /// Generate the player start position.
        /// </summary>
        private void GeneratePlayerStart()
        {
            // Get the random player start position
            var playerPosition = TAWorldFactory.BuildPlayerStartPosition();

            // Load the corresponding tile to display it
            worldMap.tilemap.SetTile(playerPosition, TATileLoader.LoadPlayerStartTile());
        }
        #endregion
        
    }
}