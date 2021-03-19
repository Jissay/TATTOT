using System.Collections.Generic;
using UnityEngine;

public class TAWorldFactory
{
    private static readonly TATerrain[] availableTerrains =
        new TATerrain[] { new TAGrass(), new TARock(), new TASand(), new TAWater() };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static IDictionary<Vector3Int, TATerrain> BuildWithSize(Vector2Int size)
    {
        Debug.Log("[ Starting world generation ]");

        // 1 - Build a matrix to contain data
        IDictionary<Vector3Int, TATerrain> terrainMatrix = new Dictionary<Vector3Int, TATerrain>();
        System.Random random = new System.Random();

        // 2 - Fill the array randomly using the given size
        for (int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                // Pick a terrain from the availableTerrains
                int selectedTerrain = random.Next(0, availableTerrains.Length);

                // Create a tuple with position and terrain
                terrainMatrix.Add(new Vector3Int(x, y, 0), availableTerrains[selectedTerrain]);
            }
        }

        return terrainMatrix;
    }

    /// <summary>
    /// Using the current world size, we found a position that is far enough
    /// from the edge of the map.
    /// </summary>
    /// <param name="worldSize"></param>
    /// <returns>The start position as a <see cref="Vector3Int"/></returns>
    public static Vector3Int BuildPlayerStartPosition()
    {
        /// Load the <see cref="TAConfiguration"/> parameters
        TAConfiguration config = TAConfigurationLoader.GetConfiguration();
        Vector2Int worldSize = config.WorldMapSize();
        int maxEdgeReach = config.StartMapEdgeMaxReach();

        /// Set the generate parameters
        int minEdgeReach = 0 + maxEdgeReach;
        int maxWidthReach = worldSize.x - maxEdgeReach;
        int maxHeightReach = worldSize.y - maxEdgeReach;

        /// Randomly select a player start position
        int randomX = new System.Random().Next(minEdgeReach, maxWidthReach);
        int randomY = new System.Random().Next(minEdgeReach, maxHeightReach);

        return new Vector3Int(randomX, randomY, 0);
    }
}
