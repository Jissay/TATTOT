using Code.Logic.Terrain;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.ResourcesLoaders
{
    public static class TATileLoader
    {
        private const string TilesPath = "Tiles/";
        
        public static Tile LoadOpponentStartTile()
        {
            return Resources.Load<Tile>(TilesPath + TATileKeys.OpponentStartPosition);
        }
        
        public static Tile LoadPlayerStartTile()
        {
            return Resources.Load<Tile>(TilesPath + TATileKeys.PlayerStartPosition);
        }

        public static Tile LoadTileFromTerrain(TATerrain terrain)
        {
            return Resources.Load<Tile>(TilesPath + terrain.TileName);
        }

        #region UI Tiles

        public static Tile LoadUISelectedTile()
        {
            return Resources.Load<Tile>(TilesPath + TATileKeys.Selected);
        }

        #endregion
    }

    internal struct TATileKeys
    {
        public const string OpponentStartPosition = "OpponentStartPosition";
        public const string PlayerStartPosition = "PlayerStartPosition";
        public const string Selected = "Selected";
    }
}