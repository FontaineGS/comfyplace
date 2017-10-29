using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities;

namespace _3Dviewer
{
    public class ImageEncoder
    {
        public ImageEncoder()
        {
        }

        public void Encode(Terrain terrain)
        {
            int SIZE = terrain.SIZE;
            Bitmap image = new Bitmap(SIZE, SIZE, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            for(int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {//On construit une valeur de couleur comprises linéairement entre 0 et 255 à partir des données du tableaux
                    var maxvalue = (255 + 1) * 1.25;
                    var coeff = 255 / maxvalue;
                    //we need to reduce this value to 255



                    int color = (int)(terrain.HeightMap[i, j]*coeff);
                    //Console.WriteLine(color);
                    var colorvalue = Color.FromArgb(color, color, color);
                    image.SetPixel(i, j, colorvalue );
                }
            }
            using (MemoryStream m = new MemoryStream())
            {

                image.Save("C:\\TEST.png", ImageFormat.Png);
            }

        }
        

        public void Decode(Terrain terrain_, string path_)
        {
            int SIZE = terrain_.SIZE;
            Bitmap image = new Bitmap(path_);
            for (int i =0; i<= SIZE-1; i++)
            {
                for (int j = 0; j <= SIZE-1; j++)
                {
                    terrain_.HeightMap[i, j] = image.GetPixel(i, j).R;
                }
            }
            
        }

        public void Trim()
        {
            
        }
    }
}
