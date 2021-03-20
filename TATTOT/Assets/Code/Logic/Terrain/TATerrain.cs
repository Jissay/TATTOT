namespace Code.Model.Terrain
{
    public abstract class TATerrain
    {
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
