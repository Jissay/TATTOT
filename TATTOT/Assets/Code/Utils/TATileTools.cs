using System.Collections.Generic;
using System.Linq;
using Code.Logic.Terrain;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Utils
{
    public static class TATileTools
    {
        #region Tile movement

        /// <summary>
        /// Get the coordinates of a position, at the end of a path. The path is computed given a start position,
        /// a direction to go and a number of tiles we have to travel through.
        /// </summary>
        /// <param name="start">Start position of the path.</param>
        /// <param name="directionIndex">Direction to go for the path.</param>
        /// <param name="steps">Number of steps to do.</param>
        /// <returns>The last position of the path.</returns>
        private static Vector3Int GetToDirection(Vector3Int start, TATilesDirections directionIndex, int steps)
        {
            var finish = start;
            for (var i = 0; i < steps; i++) { finish += directionIndex.GetVector(start); }
            return finish;
        }

        #endregion

        #region Tile surroundings

        /// <summary>
        /// Get neighbors from a given <see cref="Tile"/> position.
        /// </summary>
        /// <param name="position">Position where to find neighbors.</param>
        /// <returns>All neighbors of the current position.</returns>
        public static List<Vector3Int> GetNeighbors(Vector3Int position)
        {
            return TATilesDirectionsHelper.GetAllVectors(position).Select(direction => position + direction).ToList();
        }

        #endregion

        #region Tile range selection

        /// <summary>
        /// Get all positions of tiles within a given radius, from a center.
        /// See <see><cref>https://www.redblobgames.com/grids/hexagons/#rings</cref> </see>
        /// for more information.
        /// </summary>
        /// <param name="center">Center of the radius to get tiles from.</param>
        /// <param name="radius">Radius of the circle from where to get tiles.</param>
        /// <returns>List of tiles positions</returns>
        public static IEnumerable<Vector3Int> GetTilesInRadius(Vector3Int center, int radius)
        {
            var results = new List<Vector3Int>();

            // We gather a tile ring for each step towards the end of the radius
            // Ex: for a radius of 3, we combine the result of GetTileRing for a radius of 1,2 and 3.
            for (var currentRadius = 1; currentRadius <= radius; currentRadius++)
            {
                results.AddRange(GetTileRing(center, currentRadius));
            }

            return results;
        }

        /// <summary>
        /// Get all positions of tiles drawing a circle around a given center, of a given radius.
        /// See <see> <cref>https://www.redblobgames.com/grids/hexagons/#rings</cref> </see>
        /// for more information.
        /// </summary>
        /// <param name="center">Center of the radius to draw a circle and get tiles from.</param>
        /// <param name="radius">Radius of the circle to get tiles from.</param>
        /// <returns>List of tiles positions.</returns>
        private static IEnumerable<Vector3Int> GetTileRing(Vector3Int center, int radius)
        {
            var results = new List<Vector3Int>();
            
            // Pick the 4th direction as this is the one we can use to start from index 0
            // while running through all directions in the next step.
            // We start from a given point, from the radius distance of the center.
            var currentTile = GetToDirection(center, TATilesDirections.West, radius);
            results.Add(currentTile);

            var directionsArray = TATilesDirectionsHelper.GetAllVectors(currentTile);
            // We run through each direction
            foreach (var direction in directionsArray)
            {
                // We make a number of steps equivalent to the radius,
                // this is a "side" of our ring.
                for (var steps = 0; steps < radius; steps++)
                {
                    currentTile += direction;
                    results.Add(currentTile);
                }
                // When the side of our ring is done, we move to next direction to continue
                // running around the center.
            }

            return results;
        }

        #endregion
    }
}