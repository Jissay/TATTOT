namespace Code.Logic.Terrain
{
    public abstract class TATerrain
    {
        public bool IsValidStartPosition = true;
        public readonly int Tier;
        public int Height;

        public int AvailableSlots => GetSlotsFromTier(Tier);

        public string TileName => GetTileName();

        protected TATerrain(int tier)
        {
            Tier = tier;
        }
        
        /// <summary>
        /// Get the tile name from the <see cref="TATerrain"/> type.
        /// </summary>
        /// <returns></returns>
        private string GetTileName()
        {
            // Removing the "TA" prefix from the terrain type
            return GetType().Name.Remove(0, 2); 
        }

        private static int GetSlotsFromTier(int tier)
        {
            return tier switch
            {
                1 => 1,
                2 => 3,
                _ => 5
            };
        }
    }
}
