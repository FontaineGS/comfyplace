using CV.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    Engine engine { get; set; }
    float __timeSinceLastUpdate = 0f;
    float _lastRecordedTime;

    public bool set = false;
    // Start is called before the first frame update
    void Start()
    {
        engine = FindObjectOfType<Engine>() as Engine;
    }

    // Update is called once per frame
    void Update()
    {
        var curTime = Time.realtimeSinceStartup;
        __timeSinceLastUpdate += curTime - _lastRecordedTime;

        
        if (engine.Job == null)
        {
                        engine.UpdateTerrain();
        }
        if (engine.Job.IsCompleted)
        {
            var TerrainData = GetComponent<UnityEngine.Terrain>().terrainData;
            var terrain = engine.World.Terrain.HeightMap;
            LoadTerrain(terrain, terrain.Size, TerrainData);

            engine.UpdateTerrain();
            __timeSinceLastUpdate = 0;
        }

        _lastRecordedTime = curTime;
    }

    void LoadTerrain(HeightMap terrain, int size, TerrainData aTerrain)
    {
        float[,] data = new float[size, size];
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float v = (float)terrain[x, y] / 255f;
                data[y, x] = v;
            }
        }
        aTerrain.SetHeights(0, 0, data);
    }
}
