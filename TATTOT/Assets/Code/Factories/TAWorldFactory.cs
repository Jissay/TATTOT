using System.Collections.Generic;
using System.Linq;
using Code.GameObjects;
using Code.Logic.Terrain;
using Code.ResourcesLoaders;
using Code.Utils;
using UnityEngine;
using Random = System.Random;

namespace Code.Factories
{
    public static class TAWorldFactory
    {
        private static readonly TATerrainFactory[] TerrainTypes = 
            { new TAGrassFactory(), new TARockFactory(), new TASandFactory(), new TAWaterFactory() };

        /// <summary>
        /// Build a new map with a given size.
        /// </summary>
        /// <param name="size">Size of the map to build.</param>
        /// <returns>The new built map.</returns>
        public static Dictionary<Vector3Int, TATerrain> BuildWithSize(Vector2Int size)
        {
            // 0. - Build a matrix to contain data, gather world configuration data.
            var terrainMatrix = new Dictionary<Vector3Int, TATerrain>();
            var maxReach = TAConfigurationLoader.GetConfiguration().startMapEdgeMaxReach;
            var grassRadius = TAConfigurationLoader.GetConfiguration().grassRadius;
            var mountainRadius = TAConfigurationLoader.GetConfiguration().mountainRadius;
            var sandRadius = TAConfigurationLoader.GetConfiguration().sandRadius;
            
            // 1. - Create an array of vector3Int that shows all slots to fill in for world generation
            var availableSlots = new List<Vector3Int>();
            for (var x = 0; x < size.x; x++)
            {
                for(var y = 0; y < size.y; y++)
                {
                    availableSlots.Add(new Vector3Int(x, y, 0));
                }
            }
            
            // 2. Pick how many mountains there is in the map
            var howManyMountains = new Random().Next(5, 15);
            
            // 3. Generate mountains, and give them radius
            var rockFactory = new TARockFactory();
            var mountainPositions = new List<Vector3Int>();
            for (var m = 0; m < howManyMountains; m++)
            {
                // Get random available position
                var randomSlot = new Random().Next(0, availableSlots.Count - 1);
                var newMountainSlot = availableSlots[randomSlot];

                // Create new mountain, calculate max reach for opponent placing then add it to the matrix
                var mountain = rockFactory.Create(1);  //TODO: Tier is not random
                mountain.IsValidStartPosition = IsWithinMaxReach(newMountainSlot.x, newMountainSlot.y, maxReach, size);
                terrainMatrix.Add(newMountainSlot, mountain);

                // Then remove available slot, and store mountain position for further use
                availableSlots.Remove(newMountainSlot);
                mountainPositions.Add(newMountainSlot);
            }
            
            // 4. Add some more mountains to add more realistic variations
            FillMatrixWithTerrainType(size, mountainPositions, availableSlots, new TARockFactory(), maxReach, terrainMatrix, mountainRadius, true);

            //TODO: Min-max range for grass and sand + get it from mountain radius
            
            // 5. Fill grass, with random radius, based on mountain radius
            FillMatrixWithTerrainType(size, mountainPositions, availableSlots, new TAGrassFactory(), maxReach, terrainMatrix, grassRadius);
            
            // 6. Fill sand around grass, with random radius, based on grass radius
            FillMatrixWithTerrainType(size, mountainPositions, availableSlots, new TASandFactory(), maxReach, terrainMatrix, sandRadius);

            // 7. Fill water where it's empty
            var waterFactory = new TAWaterFactory();
            foreach (var newWaterSlot in availableSlots)
            {
                var water = waterFactory.Create(1); //TODO: Tier is not random
                water.IsValidStartPosition = false;
                terrainMatrix.Add(newWaterSlot, water);
            }
            
            return terrainMatrix;
        }

        private static void FillMatrixWithTerrainType(Vector2Int size, 
                                                      List<Vector3Int> mountainPositions, 
                                                      ICollection<Vector3Int> availableSlots, 
                                                      TATerrainFactory terrainFactory, 
                                                      int maxReach,
                                                      IDictionary<Vector3Int, TATerrain> terrainMatrix,
                                                      int rangeFromTop, 
                                                      bool variableRadius = false)
        {
            foreach (var mountain in mountainPositions)
            {
                var newRadius = rangeFromTop;
                if (variableRadius)
                {
                    newRadius = new Random().Next(0, rangeFromTop);
                }
                
                var newGrassSlots = TATileTools.GetTilesInRadius(mountain, newRadius).Where(availableSlots.Contains);
                foreach (var newSlot in newGrassSlots)
                {
                    var terrain = terrainFactory.Create(1); //TODO: Tier is not random
                    terrain.IsValidStartPosition = IsWithinMaxReach(newSlot.x, newSlot.y, maxReach, size);
                    terrainMatrix.Add(newSlot, terrain);

                    availableSlots.Remove(newSlot);
                }
            }
        }


        /// <summary>
        /// Using the current world size, we found a position that is far enough
        /// from the edge of the map.
        /// </summary>
        /// <returns>The start position as a <see cref="Vector3Int"/></returns>
        public static Vector3Int BuildStartPosition(TAWorldMap worldMap)
        {
            // 1 - Filter out non-valid start positions and gather the result as a list
            var validStartPositions =
                worldMap.WorldData.Where(kvp => kvp.Value.IsValidStartPosition)
                                  .Select(kv => kv.Key)
                                  .ToList();

            // 2 - Get a random one within all the valid positions
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
