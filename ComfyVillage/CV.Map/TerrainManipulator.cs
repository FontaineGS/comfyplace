using CV.Map.basicStruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Map
{
    internal static class TerrainManipulator
    {
        private static int maxIterations = 20;
        private static float depositionRate = 0.02f;
        private static float erosionRate = 0.02f;
        private static float iterationScale = 1f;
        private static float friction = 0.02f;
        private static float speed = 0.1f;
        private static int radius = 3;


        #region erosion


        private static void PutSnowball(double[,] heightMap, float x, float y, int size)
        {
            var r = new Random();
            var ox = (float)r.NextDouble();
            var oy = (float)r.NextDouble();

            float xp = x;
            float yp = y;
            float vx = 0;
            float vy = 0;
            var sediment = 0.0f;

            for (int i = 0; i < maxIterations; i++)
            {

                var surfaceNormal = SampleNormal(heightMap, x + ox * radius, y + oy * radius, size);

                // If the terrain is flat, stop simulating, the snowball cannot roll any further
                if (surfaceNormal.Z == 1)
                    break;

                // Calculate the deposition and erosion rate
                var deposit = sediment * depositionRate * surfaceNormal.Z;
                var erosion = erosionRate * (1 - surfaceNormal.Z) * Math.Min(1, i * iterationScale);

                // Change the sediment on the place this snowball came from
                Change(heightMap, xp, yp, deposit - erosion);
                sediment += erosion - deposit;

                vx = friction * vx + surfaceNormal.X * speed;
                vy = friction * vy + surfaceNormal.Y * speed;
                xp = x;
                yp = y;
                x += vx;
                y += vy;
            }
        }

        public static void RunErosionTick(double[,] heightMap, int size)
        {
            for (int i = 1; i < size - 1; i++)
            {
                for (int j = 1; j < size - 1; j++)
                {
                    PutSnowball(heightMap, i, j, size);
                }
            }
        }

        private static void Change(double[,] heightMap, float xp, float yp, float deposit)
        {
            heightMap[(int)xp, (int)yp] += deposit;

        }

        private static Vector SampleNormal(double[,] heightMap, float x, float y, int size)
        {
            int v1 = (int)x;
            int v2 = (int)y;

            if (v1 <= 0 || v2 <= 0 ||v1 >= size - 1 || v2 >= size -1) return new Vector(0, 0, 1);
            var N = heightMap[v1, v2 + 1];
            var S = heightMap[v1, v2 - 1];
            var W = heightMap[v1 - 1, v2];
            var E = heightMap[v1 + 1, v2];

            return new Vector()
            {
                X = (float)(2 * (W - E)),
                Y = (float)(2 * (N - S)),
                Z = 4
            }.Normalize();

        }


        #endregion
    }
}
