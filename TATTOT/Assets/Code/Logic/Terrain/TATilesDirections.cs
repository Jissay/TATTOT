using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic.Terrain
{
    public enum TATilesDirections: int
    {
        NorthEast = 0,
        East = 1, 
        SouthEast = 2, 
        SouthWest = 3, 
        West = 4, 
        NorthWest = 5
    }

    public static class TATilesDirectionsHelper
    {
        public static IEnumerable<Vector3Int> GetAllVectors(Vector3Int fromStart)
        {
            return new[]
            {
                TATilesDirections.NorthEast.GetVector(fromStart),
                TATilesDirections.East.GetVector(fromStart),
                TATilesDirections.SouthEast.GetVector(fromStart),
                TATilesDirections.SouthWest.GetVector(fromStart),
                TATilesDirections.West.GetVector(fromStart),
                TATilesDirections.NorthWest.GetVector(fromStart)
            };
        }
    }
    
    internal static class TATilesDirectionsExtensions
    {
        public static Vector3Int GetVector(this TATilesDirections payload, Vector3Int fromStart)
        {
            return fromStart.y % 2 == 0 ? payload.EvenRowDirection() : payload.OddRowsDirections();
        }
        
        /*
           Note that we need two arrays, as each direction is different based if the current tile row is
           an odd or even number. See https://www.redblobgames.com/grids/hexagons/#coordinates-offset for
           more information about coordinates representation.
        */

        private static Vector3Int EvenRowDirection(this TATilesDirections payload)
        {
            return payload switch
            {
                TATilesDirections.NorthEast => new Vector3Int(0, -1, 0),
                TATilesDirections.East => new Vector3Int(1, 0, 0),
                TATilesDirections.SouthEast => new Vector3Int(0, 1, 0),
                TATilesDirections.SouthWest => new Vector3Int(-1, 1, 0),
                TATilesDirections.West => new Vector3Int(-1, 0, 0),
                TATilesDirections.NorthWest => new Vector3Int(-1, -1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(payload), payload, null)
            };
        }

        private static Vector3Int OddRowsDirections(this TATilesDirections payload)
        {
            return payload switch
            {
                TATilesDirections.NorthEast => new Vector3Int(1, -1, 0),
                TATilesDirections.East => new Vector3Int(1, 0, 0),
                TATilesDirections.SouthEast => new Vector3Int(1, 1, 0),
                TATilesDirections.SouthWest => new Vector3Int(0, 1, 0),
                TATilesDirections.West => new Vector3Int(-1, 0, 0),
                TATilesDirections.NorthWest => new Vector3Int(0, -1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(payload), payload, null)
            };
        }
    }
}