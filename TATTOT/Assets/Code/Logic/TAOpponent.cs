using UnityEngine;
using Random = System.Random;

namespace Code.Logic
{
    public class TAOpponent
    {
        #region Meta-data

        public readonly string Name;
        private bool _isPLayerControlled;
        
        #endregion

        #region Game-wise data

        public Vector3Int StartPosition;

        #endregion

        public TAOpponent(bool isPLayerControlled = false)
        {
            _isPLayerControlled = isPLayerControlled;
            Name = CreateRandomString(15);
        }
        
        private static string CreateRandomString(int stringLength = 10) 
        {
            var totalLength = stringLength - 1;
            var randomString = "";
            var random = new Random();
            var characters = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            for (var i = 0; i <= totalLength; i++)
            {
                randomString += characters[random.Next(characters.Length -1)];
            }
            return randomString;
        }
    }
}
