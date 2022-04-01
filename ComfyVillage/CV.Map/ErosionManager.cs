using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CV.Map
{
    public class ErosionManager
    {

        private float _dt = 0.1f;
        private Particle _particle;
        private float _friction = 0.01f;
        private float _density = 1f;
        private float _evapRate = 0.05f;
        private float _depositionRate = 1f;


        public int X => (int)_particle.pos.X;
        public int Y => (int)_particle.pos.Y;

        public void Init(float x, float y)
        {
            _particle = new Particle(x, y);
        }

        public bool Step(HeightMap heightMap)
        {
            if (_particle is null)
                return false;

            if (_particle.volume <= 0.01)
                return false;

            //moving
            var ipos = _particle.pos;
            var normale = heightMap.Normale(ipos.X, ipos.Y);


            _particle.speed += _dt * new Vector2(normale.X, normale.Y) / (_particle.volume * _density);
            _particle.pos += _dt * _particle.speed;
            _particle.speed *= (float)(1.0 - _dt * _friction);  //Friction Factor

            if (IsOutside(heightMap, _particle.pos)) return false;
            //mass transfer

            float c_eq = _particle.volume * _particle.speed.Length() * (float)(heightMap[(int)ipos.X, (int)ipos.Y] - heightMap[(int)_particle.pos.X, (int)_particle.pos.Y]);

            if (c_eq < 0.0) c_eq = 0;

            float cdiff = c_eq - _particle.sediment;

            _particle.sediment += _dt * _depositionRate * cdiff;
            UpdateHeightMap(heightMap, ipos, cdiff);

            _particle.volume *= (1.0f - _dt * _evapRate);

            return true;
        }

        private void UpdateHeightMap(HeightMap heightMap, Vector2 ipos, float cdiff)
        {
            if (!IsOutside(heightMap, ipos))
                heightMap[(int)ipos.X, (int)ipos.Y] -= _dt * _particle.volume * _depositionRate * cdiff;
        }

        public bool IsOutside(HeightMap heightMap, Vector2 ipos)
        {
            return (ipos.X <= 0 || ipos.Y <= 0 || ipos.X >= heightMap.Size - 1 || ipos.Y >= heightMap.Size - 1);
        }

        private class Particle
        {
            // drop
            public Vector2 pos;

            public Vector2 speed;


            public float volume = 1.0f;
            public float sediment = 0;

            public Particle(float x, float y)
            {
                pos = new Vector2(x, y);
            }
        }
    }





}
