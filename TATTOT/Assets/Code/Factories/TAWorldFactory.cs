using System.Collections.Generic;
using Code.Loaders;
using Code.Model.Terrain;
using UnityEngine;
using Random = System.Random;

namespace Code.Factories
{
    public static class TAWorldFactory
    {
        private static readonly TATerrainFactory[] AvailableTerrains =
            { new TAGrassFactory(), new TARockFactory(), new TASandFactory(), new TAWaterFactory() };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IDictionary<Vector3Int, TATerrain> BuildWithSize(Vector2Int size)
        {
            // 1 - Build a matrix to contain data
            IDictionary<Vector3Int, TATerrain> terrainMatrix = new Dictionary<Vector3Int, TATerrain>();
            var random = new Random();

            // 2 - Fill the array randomly using the given size
            for (var x = 0; x < size.x; x++)
            {
                for(var y = 0; y < size.y; y++)
                {
                    // Pick a terrain from the availableTerrains
                    var terrainType = random.Next(0, AvailableTerrains.Length);

                    // Create a tuple with position and terrain
                    terrainMatrix.Add(new Vector3Int(x, y, 0), AvailableTerrains[terrainType].Create());
                }
            }

            return terrainMatrix;
        }

        /// <summary>
        /// Using the current world size, we found a position that is far enough
        /// from the edge of the map.
        /// </summary>
        /// <returns>The start position as a <see cref="Vector3Int"/></returns>
        public static Vector3Int BuildPlayerStartPosition()
        {
            // 1 - Load the configuration parameters
            var config = TAConfigurationLoader.GetConfiguration();
            var worldSize = config.WorldMapSize();
            var maxEdgeReach = config.StartMapEdgeMaxReach();

            // 2 - Set the generate parameters
            var minEdgeReach = 0 + maxEdgeReach;
            var maxWidthReach = worldSize.x - maxEdgeReach;
            var maxHeightReach = worldSize.y - maxEdgeReach;

            // 3 - Randomly select a player start position
            var random = new Random();
            var randomX = random.Next(minEdgeReach, maxWidthReach);
            var randomY = random.Next(minEdgeReach, maxHeightReach);

            return new Vector3Int(randomX, randomY, 0);
        }
    }
}
