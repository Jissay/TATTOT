using Code.Logic.Terrain;

namespace Code.Factories
{
    public abstract class TATerrainFactory
    {
        public abstract TATerrain Create(int tier);
    }

    public class TAGrassFactory: TATerrainFactory
    {
        public override TATerrain Create(int tier) { return new TAGrass(tier); }
    }
    
    public class TARockFactory: TATerrainFactory
    {
        public override TATerrain Create(int tier) { return new TARock(tier); }
    }
    
    public class TASandFactory: TATerrainFactory
    {
        public override TATerrain Create(int tier) { return new TASand(tier); }
    }
    
    public class TAWaterFactory: TATerrainFactory
    {
        public override TATerrain Create(int tier) { return new TAWater(tier); }
    }
}