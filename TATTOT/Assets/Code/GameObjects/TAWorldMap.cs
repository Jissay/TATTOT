using System.Collections.Generic;
using System.Linq;
using Code.Logic.Terrain;
using Code.ResourcesLoaders;
using Code.Utils;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.GameObjects
{
    public class TAWorldMap : MonoBehaviour
    {
        #region Unity Game objects

        public Tilemap tilemap;

        #endregion

        #region TA Game objects

        /// <summary>
        /// World data stored along the main <see cref="Tilemap"/>.
        /// Each entry is a <see cref="TATerrain"/> instance, with its own parameters.
        /// </summary>
        public Dictionary<Vector3Int, TATerrain> WorldData { get; set; }

        #endregion

        #region MonoBehaviour implementation

        private void Start() { }

        #endregion

        #region WorldMap updates

        public void SetNewStartPosition(Vector3Int newPosition, bool isAPlayer)
        {
            ClearEligibleStartPositions(newPosition);
            
            // Update the tile displayed to match and show the new start position
            //TODO: change when the start tile is ready
            tilemap.SetTile(newPosition, isAPlayer ? TATileLoader.LoadTileFromTerrain(new TARock()) : TATileLoader.LoadOpponentStartTile());
        }

        private void ClearEligibleStartPositions(Vector3Int newPosition)
        {
            // 1. The new start position is no longer eligible for being a start position (as it already is)
            WorldData[newPosition].IsValidStartPosition = false;

            // 2. Load the max reach parameter from the configuration
            var maxReach = TAConfigurationLoader.GetConfiguration().opponentMaxReach;
            
            // 3. Gather the surroundings of the new start position
            var centerX = newPosition.x;
            var centerY = newPosition.y;

            foreach (var tile in TATileTools.GetTilesInRadius(newPosition, maxReach))
            {
                SetPositionAsNotEligible(tile.x, tile.y);
            }
        }

        private void SetPositionAsNotEligible(int x, int y)
        {
            var position = new Vector3Int(x, y, 0);
            WorldData[position].IsValidStartPosition = false;
            tilemap.SetTile(position, TATileLoader.LoadPlayerStartTile());
        }

        #endregion
    }
}
