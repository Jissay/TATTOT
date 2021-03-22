using Code.Logic.Terrain;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.ResourcesLoaders
{
    public static class TATileLoader
    {
        public static Tile LoadOpponentStartTile()
        {
            return Resources.Load<Tile>("Tiles/OpponentStartPosition");
        }
        
        public static Tile LoadPlayerStartTile()
        {
            return Resources.Load<Tile>("Tiles/PlayerStartPosition");
        }

        public static Tile LoadTileFromTerrain(TATerrain terrain)
        {
            return Resources.Load<Tile>("Tiles/" + terrain.GetTileName());
        }
    }
}