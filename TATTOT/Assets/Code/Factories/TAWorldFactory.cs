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
        // 1 - Build a matrix to contain data
        IDictionary<Vector3Int, TATerrain> terrainMatrix = new Dictionary<Vector3Int, TATerrain>();

        // 2 - Fill the array randomly using the given size
        for (int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                Debug.Log($"Generating for ({x}, {y})");

                // Pick a terrain from the availableTerrains
                int selectedTerrain = new System.Random().Next(0, availableTerrains.Length);

                // Create a tuple with position and terrain
                terrainMatrix.Add(new Vector3Int(x, y, 0), availableTerrains[selectedTerrain]);
            }
        }

        return terrainMatrix;
    }
}
