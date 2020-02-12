using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV.Map
{
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
            PRECISION = 7;
            SIZE = (int)Math.Pow(2, PRECISION) + 1;
        }
        public void Init()
        {

            HeightMap = new double[SIZE, SIZE];
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
