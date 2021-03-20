using System;
using Code.Model.Terrain;

namespace Code.Factories
{
    public class TATerrainFactory<T> where T : TATerrain, new()
    {
        public T Create()
        {
            return new T();
        }
    }
}