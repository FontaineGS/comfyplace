using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CV.Map
{
    public class HeightMap
    {
        private int _size;
        public int Size => _size;

        //substrate
        public double[,] WaterLevel { get; set; } = null;

        private double[,] _sedimentation = null;
        private double[,] _rock = null;

        public double[,] Sedimentation => _sedimentation;
        public double[,] Rock => _rock;

        


        public HeightMap(int size)
        {
            _size = size;
            _rock = new double[size, size];
            _sedimentation = new double[size, size];
            WaterLevel = new double[size, size];


        }

        public HeightMap(double[,] data, int size)
        {
            _size = size;
            WaterLevel = new double[size, size];
            _rock = data;
            _sedimentation = new double[size,size];

        }

        public Vector3 Normale( float x, float y)
        {
            int v1 = (int)x;
            int v2 = (int)y;

            if (v1 <= 0 || v2 <= 0 || v1 >= _size - 1 || v2 >= _size - 1) return new Vector3(0, 0, 1);
            var N = this[v1, v2 + 1];
            var S = this[v1, v2 - 1];
            var W = this[v1 - 1, v2];
            var E = this[v1 + 1, v2];

            var result = new Vector3()
            {
                X = (float)(2 * (W - E)),
                Y = (float)(2 * (S - N)),
                Z = 4
            };

            return Vector3.Normalize(result);
        }

        public double this[int x, int y]
        {
            get => _rock[x, y] + _sedimentation[x, y];
        }
    }
}
