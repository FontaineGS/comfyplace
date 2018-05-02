using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainUtilities.basicStruct
{
    public class Vector
    {
        
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        //Unités : m
        [Key]
        public Guid Id { get; set; }

        public Vector()
        {
            Id = Guid.NewGuid();
        }

        public static Vector operator -(Vector w1, Vector w2)
        {
            return new Vector() { X = w1.X - w2.X, Y = w1.Y - w2.Y, Z = w1.Z - w2.Z };
        }

        public static Vector operator +(Vector w1, Vector w2)
        {
            return new Vector() { X = w1.X + w2.X, Y = w1.Y + w2.Y, Z = w1.Z + w2.Z };
        }

        public static Vector operator /(Vector w1, float w2)
        {
            return new Vector() { X = w1.X /w2, Y = w1.Y / w2, Z = w1.Z / w2 };
        }

    }
}
