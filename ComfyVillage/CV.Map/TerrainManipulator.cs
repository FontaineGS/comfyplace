using CV.Map.basicStruct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CV.Map
{
    internal class TerrainManipulator
    {

        #region erosion


        public void RunErosionTick(HeightMap heightMap, int size, int repeat)
        {
            for (int i = 0; i <repeat* manager.MaxIterations; i++)
            {
                StepErode(size, heightMap);
            }
        }


        #region step by step

        public SnowballManager manager = new SnowballManager();

        bool started = false;

        public void StepErode(int size, HeightMap map)
        {
            if (!started)
            {
                var r = new Random();
                var x = r.Next(1, size - 1);
                var y = r.Next(1, size - 1);
                manager.Start(map, x, y, size);
                started = true;
            }
            else
            {
                if (!manager.Step())
                    started = false;
            }
        }

        #endregion

        #endregion

        #region river
        private (int x, int y) _source;

        private void CreateSource(int x, int y)
        {
            _source = (x, y);
        }

        public void Step(HeightMap map)
        {
            map.WaterLevel[_source.x, _source.y] += 0.1;
            for (int x = 1; x <= map.Size - 2; x++)
            {
                for (int y = 1; y <= map.Size - 2; y++)
                {
                    var ele = map[x, y];
                    var lvl = map.WaterLevel[x, y];
                    if (lvl <= 0) continue;

                    map.Normale(x, y);

                    //TOP
                    var top_el = map[x, y + 1];
                    var top_wl = map.WaterLevel[x, y + 1];
                    bool top_go = top_el + top_wl < ele + lvl;

                    //BOT
                    var bot_el = map[x, y - 1];
                    var bot_wl = map.WaterLevel[x, y - 1];
                    bool bot_go = bot_el + bot_wl < ele + lvl;

                    //LEFT
                    var left_el = map[x - 1, y];
                    var left_wl = map.WaterLevel[x - 1, y];
                    bool left_go = left_el + left_wl < ele + lvl;

                    //RIGHT
                    var right_el = map[x + 1, y];
                    var right_wl = map.WaterLevel[x + 1, y];
                    bool right_go = right_el + right_wl < ele + lvl;

                    var divFactor = new bool[] { top_go, bot_go, left_go, right_go }.Where(s => s).Count();

                    if (top_go)
                    {
                        map.WaterLevel[x, y + 1] += 0.05 % divFactor;
                    }
                    if (bot_go)
                    {
                        map.WaterLevel[x, y - 1] += 0.05 % divFactor;
                    }
                    if (left_go)
                    {
                        map.WaterLevel[x - 1, y] += 0.05 % divFactor;
                    }
                    if (right_go)
                    {
                        map.WaterLevel[x + 1, y] += 0.05 % divFactor;
                    }
                }
            }
        }


        public void RunRiver(HeightMap map, int x, int y, int iteration)
        {
            CreateSource(x, y);
            for (int i = 0; i <= iteration; i++)
            {
               
                Step(map);
            }
        }


        #endregion
    }

}

