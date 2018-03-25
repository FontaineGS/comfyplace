using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainUtilities.basicStruct
{
    public class WorldLocation : Vector
    {
        //Unités : m


        public float Distance(WorldLocation _location)
        {
            float _x = Math.Abs(_location.X + X);
            float _y = Math.Abs(_location.Y + Y);
            float _z = Math.Abs(_location.Z + Z);

            return (float)Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public static WorldLocation operator -(WorldLocation w1, WorldLocation w2)
        {
            return new WorldLocation() { X = w1.X - w2.X, Y = w1.Y - w2.Y, Z = w1.Z - w2.Z };
        }

        public static WorldLocation operator +(WorldLocation w1, WorldLocation w2)
        {
            return new WorldLocation() { X = w1.X + w2.X, Y = w1.Y + w2.Y, Z = w1.Z + w2.Z };
        }

        public static WorldLocation operator /(WorldLocation w1, float w2)
        {
            return new WorldLocation() { X = w1.X / w2, Y = w1.Y / w2, Z = w1.Z / w2 };
        }

    }
}
