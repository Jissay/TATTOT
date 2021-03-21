using Code.Logic.Terrain;

namespace Code.Factories
{
    public abstract class TATerrainFactory
    {
        public abstract TATerrain Create();
    }

    public class TAGrassFactory: TATerrainFactory
    {
        public override TATerrain Create() { return new TAGrass(); }
    }
    
    public class TARockFactory: TATerrainFactory
    {
        public override TATerrain Create() { return new TARock(); }
    }
    
    public class TASandFactory: TATerrainFactory
    {
        public override TATerrain Create() { return new TASand(); }
    }
    
    public class TAWaterFactory: TATerrainFactory
    {
        public override TATerrain Create() { return new TAWater(); }
    }
}