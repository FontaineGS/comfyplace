using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Map
{


    public enum TerrainType
    {
        Rock,
        Grass,
        Sand,
        Water
    }

    public class Terrain
    {
        [Key]
        public Guid Id { get; set; }
        public int PRECISION = 8;
        public int SIZE {get;set;}
        public double[,] HeightMap = null;

        public Terrain(int value)
        {
            PRECISION = value;
            SIZE = (int)Math.Pow(2, PRECISION) + 1;
        }

        public Terrain()
        {
            SIZE = (int)Math.Pow(2, PRECISION) + 1;
        }

        public void Erode()
        {
            TerrainManipulator.RunErosionTick(HeightMap, SIZE);
        }

    }
}
