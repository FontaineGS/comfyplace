using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Map
{
    public class SnowballManager
    {
        public (int, int) Snowball;

        Random r = new Random();
        HeightMap heightMap;
        public int X => (int)x;
        public int Y => (int)y;
        float x = 0;
        float y = 0;
        int size = 0;
        float ox = 0f;
        float oy = 0f;

        float xp = 0;
        float yp = 0;
        float vx = 0;
        float vy = 0;
        float sediment = 0.0f;
        public int iteration = 0;


        private int maxIterations = 30;
        private float depositionRate = 0.04f;
        private float erosionRate = 0.02f;
        private float iterationScale = 0.04f;
        private float friction = 0.2f;
        private float speed = 0.2f;
        private int radius = 3;

        public void Start(HeightMap map, float _x, float _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
            xp = _x;
            yp = _y;
            iteration = maxIterations;
            vx = 0;
            vy = 0;
            sediment = 0.0f;
            r = new Random();
            heightMap = map;
            ox = 0;
            oy = 0;
        }

        public bool Step()
        {
            if (iteration == 0) return false;
            iteration--;
            var surfaceNormal = heightMap.Normale(x + ox * radius, y + oy * radius);

            // If the terrain is flat, stop simulating, the snowball cannot roll any further
            if (surfaceNormal.Z == 1)
                return true;

            // Calculate the deposition and erosion rate
            var deposit = sediment * depositionRate * surfaceNormal.Z;
            var erosion = erosionRate * (1 - surfaceNormal.Z) * Math.Min(1, ((maxIterations - iteration) * iterationScale));

            // Change the sediment on the place this snowball came from
            Change(heightMap, xp, yp, deposit - erosion, size);
            sediment += erosion - deposit;

            vx = friction * vx + surfaceNormal.X * speed;
            vy = friction * vy + surfaceNormal.Y * speed;
            xp = x;
            yp = y;
            x += vx;
            y += vy;
            ox = (float)r.NextDouble()*2 -1;
            oy = (float)r.NextDouble()*2 -1;

            return true;
            
        }


        private void Change(HeightMap heightMap, float xp, float yp, float deposit, int size)
        {
            if (xp <= 0 || yp <= 0 || xp >= size - 1 || yp >= size - 1) return;

            heightMap[(int)xp, (int)yp] += deposit;
        }


    }
}
