using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldUtilities;

namespace _3Dviewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Terrain terrain = new Terrain(8);
            terrain.Init();
            TerrainBuilder builder = new TerrainBuilder();
            builder.Init(terrain);
            builder.DiamondAlgoritm();

            var encoder = new ImageEncoder();
            //  encoder.Encode(terrain);
            encoder.Decode(terrain, "C:\\TEST.png");

        }
    }
}
