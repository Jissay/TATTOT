namespace Code.Logic.Terrain
{
    public abstract class TATerrain
    {
        public bool IsValidStartPosition = true;
        
        /// <summary>
        /// Get the tile name from the <see cref="TATerrain"/> type.
        /// </summary>
        /// <returns></returns>
        public string GetTileName()
        {
            // Removing the "TA" prefix from the terrain type
            return GetType().Name.Remove(0, 2); 
        }
    }
}
