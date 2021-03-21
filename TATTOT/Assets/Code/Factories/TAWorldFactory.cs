using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code.GameObjects;
using Code.Logic.Terrain;
using Code.ResourcesLoaders;
using UnityEngine;
using Random = System.Random;

namespace Code.Factories
{
    public static class TAWorldFactory
    {
        private static readonly TATerrainFactory[] TerrainTypes = 
            { new TAGrassFactory(), new TARockFactory(), new TASandFactory(), new TAWaterFactory() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Dictionary<Vector3Int, TATerrain> BuildWithSize(Vector2Int size)
        {
            // 1 - Build a matrix to contain data
            var terrainMatrix = new Dictionary<Vector3Int, TATerrain>();
            var random = new Random();

            var maxReach = TAConfigurationLoader.GetConfiguration().startMapEdgeMaxReach;
            
            // 2 - Fill the array randomly using the given size
            for (var x = 0; x < size.x; x++)
            {
                for(var y = 0; y < size.y; y++)
                {
                    // Pick a terrain from the availableTerrains
                    var terrainType = random.Next(0, TerrainTypes.Length);
                    
                    // Create the new terrain tile and set IsValidStartPosition from the max reach loaded earlier.
                    var newTerrain = TerrainTypes[terrainType].Create();
                    newTerrain.IsValidStartPosition = IsWithinMaxReach(x, y, maxReach, size);
                    
                    // Create a tuple with position and terrain
                    terrainMatrix.Add(new Vector3Int(x, y, 0), newTerrain);
                }
            }

            return terrainMatrix;
        }

        
        /// <summary>
        /// Using the current world size, we found a position that is far enough
        /// from the edge of the map.
        /// </summary>
        /// <returns>The start position as a <see cref="Vector3Int"/></returns>
        public static Vector3Int BuildStartPosition(TAWorldMap worldMap)
        {
            // 1 - Load the configuration parameters
            var config = TAConfigurationLoader.GetConfiguration();
            var worldSize = config.worldMapSize;
            var maxEdgeReach = config.startMapEdgeMaxReach;

            // 2 - Filter out non-valid start positions and gather the result as a list
            var validStartPositions =
                worldMap.WorldData.Where(kvp => kvp.Value.IsValidStartPosition)
                                  .Select(kv => kv.Key)
                                  .ToList();

            // 3 - Get a random one within all the valid positions
            var random = new Random();
            return validStartPositions[random.Next(validStartPositions.Count)];
        }

        #region Convenience tools
        
        private static bool IsWithinMaxReach(int x, int y, int maxReach, Vector2Int size)
        {
            return (x > maxReach && x < (size.x - maxReach)) && (y > maxReach && y < (size.y - maxReach));
        }

        #endregion
    }
}
