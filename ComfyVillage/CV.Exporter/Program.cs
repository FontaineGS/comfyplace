using CV.Map;
using CV.World;
using System;
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
            var _world = generator.GenerateWorldTerrain();
            generator.Populate(_world);
            var _resolver = new WorldResolver();
            _resolver.World = _world;

            var result = CreateImage(_world.Terrain.HeightMap);
            using (var stream = File.Open(@"C:\REPOS\truc.bmp", FileMode.Create))
            {

                result.Save(stream, ImageFormat.Bmp);
            }

        }

        private static Bitmap CreateImage(HeightMap data)
        {
            int width = 255; // read from file
            int height = 255; // read from file
            var bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    var value = (int)data[x,y];
                    if (value < 0) value = 0;
                    bitmap.SetPixel(x, y, Color.FromArgb(0, value, value, value));
                }

            return bitmap;
        }
    }
}
