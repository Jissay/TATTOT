using Code.Model.Terrain;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Loaders
{
    public static class TATileLoader
    {
        public static Tile LoadPlayerStartTile()
        {
            return Resources.Load<Tile>("Tiles/PlayerPosition");
        }

        public static Tile LoadTileFromTerrain(TATerrain terrain)
        {
            return Resources.Load<Tile>("Tiles/" + terrain.GetTileName());
        }
    }
}