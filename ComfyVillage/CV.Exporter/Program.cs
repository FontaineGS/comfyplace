using CV.Map;
using CV.World;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CV.Exporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // TODO: Add your initialization logic here
            WorldGenerator generator = new WorldGenerator();
            Stopwatch chrono = new Stopwatch() ;
            chrono.Start();
            var _world = generator.GenerateWorldTerrain();
            generator.Populate(_world);
            var _resolver = new WorldResolver();
            _resolver.World = _world;

            var result = CreateImage(_world.Terrain.HeightMap);
            using (var stream = File.Open(@"C:\REPOS\truc.png", FileMode.Create))
            {

                result.Save(stream, ImageFormat.Png);
            }
            Console.WriteLine($"Chrono : {chrono.Elapsed.ToString()} total");

        }

        private static Bitmap CreateImage(HeightMap data)
        {
            int width = 513; // read from file
            int height = 513; // read from file
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    var value = (int)data[x,y];
                    if (value < 0) value = 0;
                    bitmap.SetPixel(x, y, Color.FromArgb(255, value, value, value));
                }

            return bitmap;
        }
    }
}
