using System.Collections.Generic;
using Code.Logic.Events;
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
        public Tilemap uiTilemap;
        private Vector3Int? _currentSelected = null;
        
        #endregion

        #region TA Game objects

        /// <summary>
        /// World data stored along the main <see cref="Tilemap"/>.
        /// Each entry is a <see cref="TATerrain"/> instance, with its own parameters.
        /// </summary>
        public Dictionary<Vector3Int, TATerrain> WorldData { get; private set; }

        #endregion

        #region MonoBehaviour implementation

        private void Update()
        {
            // We handle only mouse left-click for now.
            if (Input.GetMouseButton(0))
            {
                GetTerrainFromMouseClick();
            }
        }

        #endregion

        #region WorldMap handling

        private void GetTerrainFromMouseClick()
        {
            if (Camera.main is null) return;
            
            // Create a ray from camera to world
            // Then create a plane object to raycast against
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var plane = new Plane(Vector3.back, tilemap.origin.z);

            // Do a Plane Raycast with your screen to world ray
            // then get the raycast to hit the plane and convert to
            // tilemap cell position.
            plane.Raycast(ray, out var hitDist);
            var clickedPos = tilemap.WorldToCell(ray.GetPoint(hitDist));
            
            // Clear currentSelected cell if there is one
            if (_currentSelected is { } currentPos)
            {
                uiTilemap.SetTile(currentPos, null);
            }
            
            // Show selection if there is a tile, and invoke event
            if (tilemap.GetTile(clickedPos) != null)
            {
                // Set new selected tile
                uiTilemap.SetTile(clickedPos, TATileLoader.LoadUISelectedTile());
                _currentSelected = clickedPos;
                
                // Invoke selection event
                TAEventManager.Shared().DidSelectTerrainEvent.Invoke(WorldData[clickedPos]);
            }
            else
            {
                // Clear current selected and send didUnselectTerrain event
                _currentSelected = null;
                TAEventManager.Shared().DidUnselectTerrainEvent.Invoke();
            }
            
            
        }

        #endregion

        #region WorldMap creates

        public void BuildTerrain(Dictionary<Vector3Int, TATerrain> terrainMatrix)
        {
            // 1. Clear the tile map
            tilemap.ClearAllTiles();
            uiTilemap.ClearAllTiles();
            
            // 2. Load each Tile using TATerrain data and create an empty
            // tile for UITileMap
            foreach(var (key, value) in terrainMatrix)
            {
                tilemap.SetTile(key, TATileLoader.LoadTileFromTerrain(value));
            }

            // 3. Store the TATerrain data along the Tilemap
            WorldData = terrainMatrix;
        }

        #endregion
        
        #region WorldMap updates

        public void SetNewStartPosition(Vector3Int newPosition, bool isAPlayer)
        {
            ClearEligibleStartPositions(newPosition);
            
            // Update the tile displayed to match and show the new start position
            tilemap.SetTile(newPosition, isAPlayer ? TATileLoader.LoadPlayerStartTile() : TATileLoader.LoadOpponentStartTile());
        }

        private void ClearEligibleStartPositions(Vector3Int newPosition)
        {
            // 1. The new start position is no longer eligible for being a start position (as it already is)
            WorldData[newPosition].IsValidStartPosition = false;

            // 2. Load the max reach parameter from the configuration
            var maxReach = TAConfigurationLoader.GetConfiguration().opponentMaxReach;
            foreach (var tile in TATileTools.GetTilesInRadius(newPosition, maxReach))
            {
                SetPositionAsNotEligible(tile.x, tile.y);
            }
        }

        private void SetPositionAsNotEligible(int x, int y)
        {
            var position = new Vector3Int(x, y, 0);
            
            // Fix in case we are getting out of bounds
            if (WorldData.ContainsKey(position))
            {
                WorldData[position].IsValidStartPosition = false;
            }
        }

        #endregion
    }
}
