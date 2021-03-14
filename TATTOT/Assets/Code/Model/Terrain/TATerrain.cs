public abstract class TATerrain
{
    public string GetTileName()
    {
        // Removing the "TA" prefix from the terrain type
        return this.GetType().Name.Remove(0, 2); 
    }
}
