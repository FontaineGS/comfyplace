﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Map
{
    public class TerrainBuilder
    {
        private Terrain Terrain = null;

        private int espace;

        public void Init(Terrain _terrain)
        {
            Terrain = _terrain;
            espace = Terrain.SIZE - 1;

             //var hmap = PerlinNoise(Terrain.SIZE);
            // var hmap = BiggyMap(Terrain.SIZE);
            var hmap = NormaleMap(Terrain.SIZE);
            //var hmap = DiamondAlgoritm(Terrain.PRECISION, Terrain.SIZE);
            //var hmap = new double[Terrain.SIZE, Terrain.SIZE];
            Terrain.HeightMap = new HeightMap(hmap, Terrain.SIZE);

            for(int i = 0; i< 30; i++)
            {
              // Terrain.Erode();
            }
         
        }





        private static double[,] DiamondAlgoritm(int Precision, int Size)
        {
            int espace = Size - 1;
            Random r = new Random();
            double[,] curHeightMap = new double[Size, Size];
            //Initialization
            curHeightMap[0, 0] = r.Next() % 255;
            curHeightMap[0, Size - 1] = r.Next() % 255;
            curHeightMap[Size - 1, 0] = r.Next() % 255;
            curHeightMap[Size - 1, Size - 1] = r.Next() % 255;

            //randominess
            int decalage = 256;

            while (espace > 1)
            {
                int demiSpace = espace / 2;
                //diamond phase
                for (int i = demiSpace; i < Size; i = i + espace)
                {
                    for (int j = demiSpace; j < Size; j = j + espace)
                    {
                        var avg = curHeightMap[i + demiSpace, j + demiSpace] + curHeightMap[i + demiSpace, j - demiSpace] + curHeightMap[i - demiSpace, j + demiSpace] + curHeightMap[i - demiSpace, j - demiSpace];
                        avg /= 4;
                        curHeightMap[i, j] = Normalize(avg + r.Next() % decalage - decalage / 2);
                    }
                }
                //carre phase
                for (int i = 0; i < Size; i += demiSpace)
                {
                    int delay = 0;
                    if (i % espace == 0)
                        delay = demiSpace;


                    for (int j = delay; j < Size; j += espace)
                    {
                        double somme = 0;
                        int n = 0;

                        if (i >= demiSpace)
                            somme = somme + curHeightMap[i - demiSpace, j];
                        n = n + 1;

                        if (i + demiSpace < Size)
                            somme = somme + curHeightMap[i + demiSpace, j];
                        n = n + 1;

                        if (j >= demiSpace)
                            somme = somme + curHeightMap[i, j - demiSpace];
                        n = n + 1;

                        if (j + demiSpace < Size)
                            somme = somme + curHeightMap[i, j + demiSpace];
                        n = n + 1;


                        curHeightMap[i, j] = Normalize((somme / n) + r.Next() % decalage - decalage / 2);
                    }
                }
                espace = demiSpace;

                //decalage /= 2;


            }



            return curHeightMap;
        }

        //private static double[,] DiamondAlgoritm(int Precision, int Size)
        //{
        //    RandomAccessPerlinNoise.NoiseGenerator truc = new RandomAccessPerlinNoise.NoiseGenerator();
        //}

        private static double[,] PerlinNoise(int Size)
        {
            var Generator = new FastNoiseLite();
            Generator.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
            Generator.SetSeed(1039);
            Generator.SetFrequency((float)0.020);
            Generator.SetFractalType(FastNoiseLite.FractalType.FBm);
            Generator.SetFractalOctaves(12);
            Generator.SetFractalLacunarity((float)1.20);
            Generator.SetFractalGain((float)0.70);
            Generator.SetFractalWeightedStrength(0);
            double[,] curHeightMap = new double[Size, Size];

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    curHeightMap[x, y] = 128 + 128 * Generator.GetNoise(x, y);
                }
            }

            return curHeightMap;
        }

        private static double[,] BiggyMap(int Size)
        {
            double[,] curHeightMap = new double[Size, Size];

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x < 60 && x > 30 && y < 60 && y > 30)
                        curHeightMap[x, y] = 128;

                    if (x < 300 && x > 80 && y <  140 && y > 50)
                        curHeightMap[x, y] = 160;
                }
            }

            return curHeightMap;
        }

        private static double[,] NormaleMap(int Size)
        {
            double[,] curHeightMap = new double[Size, Size];
            Random r = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    curHeightMap[x, y] = GetAdjustedNormaleDouble(x,y,128,80);
                }
            }

            return curHeightMap;
        }


        private static double GetNormale(double x, double esp, double ecart)
        {

            double f1 = 1 / (ecart * Math.Sqrt(2 * Math.PI));
            double fexp = (x - esp) / ecart;
            double fexpcar = Math.Exp(-(fexp * fexp) / 2.0);

            double result = f1 * fexpcar;

            return result;
        }

        private static double GetAdjustedNormale(double x, double esp, double ecart)
        {
            var n = GetNormale(x, esp, ecart);
            var max = GetNormale(esp, esp, ecart);

            double ratio = n / max;

            return ratio *  230;
        }

        private static double GetNormaleDouble(double x, double y, double esp, double ecart)
        {
            var f1 = ((x - esp) * (x - esp) / (2 * ecart * ecart) + (y - esp) * (y - esp) / (2 * ecart * ecart));
            var result = Math.Exp(-f1);
            return result;
        }

        private static double GetAdjustedNormaleDouble(double x, double y, double esp, double ecart)
        {
            var n = GetNormaleDouble(x, y, esp, ecart);
            var max = GetNormaleDouble(esp, esp, esp, ecart);
            return (n / max) * 230;
        }

        private static double BoxMullerTransfo(Random rand)
        {
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            return randStdNormal;
        }
        private static double Normalize(double value)
        {
            return Math.Max(Math.Min(value, 255), 0);
        }

    }
}
