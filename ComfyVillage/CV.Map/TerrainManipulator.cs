using CV.Map.basicStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Map
{
    internal class TerrainManipulator
    {

        #region erosion


        public void RunErosionTick(HeightMap heightMap, int size)
        {
            for (int i = 0; i < size * size * 40; i++)
            {
                StepErode(size, heightMap);
            }
        }


        #region step by step

        public SnowballManager manager = new SnowballManager();

        bool started = false;

        public void StepErode(int size, HeightMap map)
        {
            if (!started)
            {
                var r = new Random();
                var x = r.Next(1, size - 1);
                var y = r.Next(1, size - 1);
                manager.Start(map, x, y, size);
                started = true;
            }
            else
            {
                if (!manager.Step())
                    started = false;
            }

            #endregion

            #endregion

            #region river
            private (int, int) _source;

            private void CreateSource(int x, int y)
            {
            _source = (x, y);
            }

            


        #endregion
    }

    }
}
