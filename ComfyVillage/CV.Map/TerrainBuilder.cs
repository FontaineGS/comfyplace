using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Map
{
    public class TerrainBuilder
    {
        private Terrain Terrain = null;
        private Random r = new Random();

        private int espace;

        public void Init(Terrain _terrain)
        {
            Terrain = _terrain;
            espace = Terrain.SIZE - 1;
        }

        public void DiamondAlgoritm()
        {
            if (Terrain == null)
                return;
            //Initialization
            Terrain.HeightMap[0, 0] = r.Next() % 255;
            Terrain.HeightMap[0, Terrain.SIZE - 1] = r.Next() % 255;
            Terrain.HeightMap[Terrain.SIZE - 1, 0] = r.Next() % 255;
            Terrain.HeightMap[Terrain.SIZE - 1, Terrain.SIZE - 1] = r.Next() % 255;

            //randominess
            int decalage = 256;

            while (espace > 1)
            {
                int demiSpace = espace / 2;
                //diamond phase
                for (int i = demiSpace; i < Terrain.SIZE; i = i + espace)
                {
                    for (int j = demiSpace; j < Terrain.SIZE; j = j + espace)
                    {
                        var avg = Terrain.HeightMap[i + demiSpace, j + demiSpace] + Terrain.HeightMap[i + demiSpace, j - demiSpace] + Terrain.HeightMap[i - demiSpace, j + demiSpace] + Terrain.HeightMap[i - demiSpace, j - demiSpace];
                        avg /= 4;
                        Terrain.HeightMap[i, j] = Normalize(avg + r.Next() % decalage - decalage / 2);
                    }
                }
                //carre phase
                for (int i = 0; i < Terrain.SIZE; i += demiSpace)
                {
                    int delay = 0;
                    if (i % espace == 0)
                        delay = demiSpace;


                    for (int j = delay; j < Terrain.SIZE; j += espace)
                    {
                        double somme = 0;
                        int n = 0;

                        if (i >= demiSpace)
                            somme = somme + Terrain.HeightMap[i - demiSpace, j];
                        n = n + 1;

                        if (i + demiSpace < Terrain.SIZE)
                            somme = somme + Terrain.HeightMap[i + demiSpace, j];
                        n = n + 1;

                        if (j >= demiSpace)
                            somme = somme + Terrain.HeightMap[i, j - demiSpace];
                        n = n + 1;

                        if (j + demiSpace < Terrain.SIZE)
                            somme = somme + Terrain.HeightMap[i, j + demiSpace];
                        n = n + 1;


                        Terrain.HeightMap[i, j] = Normalize((somme / n) + r.Next() % decalage - decalage/2);
                    }
                }
                espace = demiSpace;
                //decalage /= 2;
            }



        }

        private double Normalize(double value)
        {
            return Math.Max(Math.Min(value, 255), 0);
        }
    }
}
