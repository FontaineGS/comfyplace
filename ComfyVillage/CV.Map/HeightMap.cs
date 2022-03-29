using CV.Map.basicStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Map
{
    public class HeightMap
    {
        private int _size;
        public int Size => _size;
        private double[,] _data  = null;

        public double[,] WaterLevel { get; set; } = null;

        public HeightMap(int size)
        {
            _size = size;
            _data = new double[size, size];
            WaterLevel = new double[size, size];

        }

        public HeightMap(double[,] data, int size)
        {
            _size = size;
            _data = data;
            WaterLevel = new double[size, size];

        }

        public Vector Normale( float x, float y)
        {
            int v1 = (int)x;
            int v2 = (int)y;

            if (v1 <= 0 || v2 <= 0 || v1 >= _size - 1 || v2 >= _size - 1) return new Vector(0, 0, 1);
            var N = _data[v1, v2 + 1];
            var S = _data[v1, v2 - 1];
            var W = _data[v1 - 1, v2];
            var E = _data[v1 + 1, v2];

            return new Vector()
            {
                X = (float)(2 * (W - E)),
                Y = (float)(2 * (S -N)),
                Z = 4
            }.Normalize();
        }

        public double this[int x, int y]
        {
            get => _data[x, y];
            set => _data[x, y] = value;
        }
    }
}
