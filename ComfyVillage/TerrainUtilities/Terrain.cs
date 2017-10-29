using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainUtilities
{
    public class Terrain
    {
        public int PRECISION = 7;
        public int SIZE;
        public double[,] HeightMap = null;

        public Terrain(int value = 4)
        {
            PRECISION  = value;
            SIZE = (int)Math.Pow(2, PRECISION) + 1;
        }
        public void Init()
        {

            HeightMap =  new double[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    HeightMap[i, j] = 0;
                }
            }
        }

      
    }
}
