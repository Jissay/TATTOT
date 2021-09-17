using Code.Factories;
using Code.GameObjects;
using Code.Logic;
using Code.Logic.Events;
using Code.ResourcesLoaders;
using UnityEngine;

namespace Code.Managers
{
    public class TAWorldManager : TAAbstractManager<TAWorldManager>
    {
        /// <summary>
        /// <see cref="TAWorldMap"/> object set in Unity UI. This is the tilemap that is displayed
        /// to the player.
        /// </summary>
        public TAWorldMap worldMap;

        #region MonoBehaviour implementation

        private void Awake()
        {
            TAEventManager.Shared().PleaseCreateWorldEvent.AddListener(CreateWorld);
        }

        #endregion
        
        #region World creation
        
        public void CreateWorld()
        {
            GenerateWorld();
            GeneratePlayerStart();
            GenerateOpponentsStart();
            
            TAEventManager.Shared().DidCreateWorldEvent.Invoke();
        }
        
        /// <summary>
        /// Generate a new <see cref="TAWorldMap"/> using the <see cref="TAWorldFactory"/>.
        ///
        /// TODO: Later on, this process should use a seed.
        /// 
        /// </summary>
        private void GenerateWorld()
        {
            Debug.Log("[ Starting world generation ]");
            
            // 1. Load the new world data using <see cref="TAWorldFactory"/>
            var terrainMatrix = TAWorldFactory.BuildWithSize(TAConfigurationLoader.GetConfiguration().worldMapSize);

            // 2. Clear the Tilemap
            worldMap.tilemap.ClearAllTiles();

            // 3. Load each Tile using TATerrain data
            foreach(var terrainData in terrainMatrix)
            {
                worldMap.tilemap.SetTile(terrainData.Key, TATileLoader.LoadTileFromTerrain(terrainData.Value));
            }

            // 4. Store the TATerrain data along the Tilemap
            worldMap.WorldData = terrainMatrix;

            // 5. Alert the game that world has been created
            TAEventManager.Shared().DidCreateWorldEvent.Invoke();
        }

        /// <summary>
        /// Generate the player start position.
        /// </summary>
        private void GeneratePlayerStart()
        {
            Debug.Log("[ Building player start position ]");
            
            // 1. Get the random player start position
            var playerPosition = TAWorldFactory.BuildStartPosition(worldMap);

            // 2. Load the corresponding tile to display it
            worldMap.SetNewStartPosition(playerPosition, true);
            
            // 3. Alert about updated player position
            TAEventManager.Shared().PleaseCreatePlayerInWorldEvent.Invoke(playerPosition);
        }

        /// <summary>
        /// Generate each <see cref="TAOpponent"/> start position on the <see cref="TAWorldMap"/>.
        /// </summary>
        private void GenerateOpponentsStart()
        {
            Debug.Log("[ Building opponents start position ]");

            var maxOpponents = TAConfigurationLoader.GetConfiguration().numberOfOpponents;

            for (var o = 0; o < maxOpponents; o++)
            {
                var opponentPosition = TAWorldFactory.BuildStartPosition(worldMap);
                worldMap.SetNewStartPosition(opponentPosition, false);
                
                // Alert that a new opponent position has been created
                TAEventManager.Shared().PleaseCreateOpponentInWorldEvent.Invoke(opponentPosition);
            }
        }

        #endregion
    }
}