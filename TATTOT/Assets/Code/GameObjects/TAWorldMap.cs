using System.Collections.Generic;
using Code.Model.Terrain;
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
        public IDictionary<Vector3Int, TATerrain> World { get; set; }

        #endregion

        #region MonoBehaviour implementation

        private void Start() { }

        #endregion
    }
}
