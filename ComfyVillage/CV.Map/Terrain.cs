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
        public HeightMap HeightMap = null;

        private TerrainManipulator Manipulator = new TerrainManipulator();

        public (int, int) Snowball => (Manipulator.manager.X, Manipulator.manager.Y)  ;
        public Terrain(int value)
        {
            PRECISION = value;
            SIZE = (int)Math.Pow(2, PRECISION) + 1;
            HeightMap = new HeightMap(SIZE);
        }

        public Terrain()
        {
            SIZE = (int)Math.Pow(2, PRECISION) + 1;
        }

        public void Erode()
        {
            Manipulator.RunErosionTick(HeightMap, SIZE);
        }

        public void ErodeStep()
        {
            Manipulator.StepErode(SIZE, HeightMap);
        }

    }
}
