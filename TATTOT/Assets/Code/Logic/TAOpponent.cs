using UnityEngine;

namespace Code.Logic
{
    public class TAOpponent
    {
        #region Meta-data

        public string Name;
        public bool IsPLayerControlled;
        
        #endregion

        #region Game-wise data

        public Vector3Int StartPosition;

        #endregion

        public TAOpponent(bool isPLayerControlled = false)
        {
            IsPLayerControlled = isPLayerControlled;
        }
    }
}
