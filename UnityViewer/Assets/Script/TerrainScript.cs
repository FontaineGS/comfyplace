using CV.Map;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        var TerrainData = GetComponent<UnityEngine.Terrain>().terrainData;
        var terrain = engine.World.Terrain.HeightMap;

        if (engine.Job == null)
        {
            engine.UpdateTerrain();
        }
        if (engine.Job.IsCompleted)
        {
            LoadTerrain(terrain, terrain.Size, TerrainData);

            engine.UpdateTerrain();
        }
        if (__timeSinceLastUpdate > 3)
        {
            PaintTerrain(terrain, terrain.Size, TerrainData);

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

                //float v = (float)terrain[x, y] / 255f;
                data[y, x] = v;
            }
        }
        aTerrain.SetHeights(0, 0, data);
    }

    void PaintTerrain(HeightMap map, int size, TerrainData terrainData)
    {


        // Splatmap data is stored internally as a 3d array of floats, so declare a new empty array ready for your custom splatmap data:
        float[,,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                // Normalise x/y coordinates to range 0-1 
                float y_01 = (float)y / (float)terrainData.alphamapHeight;
                float x_01 = (float)x / (float)terrainData.alphamapWidth;

                // Sample the height at this location (note GetHeight expects int coordinates corresponding to locations in the heightmap array)
                float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapResolution), Mathf.RoundToInt(x_01 * terrainData.heightmapResolution));

                // Calculate the normal of the terrain (note this is in normalised coordinates relative to the overall terrain dimensions)
                Vector3 normal = terrainData.GetInterpolatedNormal(y_01, x_01);

                // Calculate the steepness of the terrain
                float steepness = terrainData.GetSteepness(y_01, x_01);

                // Setup an array to record the mix of texture weights at this point
                float[] splatWeights = new float[terrainData.alphamapLayers];

                // CHANGE THE RULES BELOW TO SET THE WEIGHTS OF EACH TEXTURE ON WHATEVER RULES YOU WANT

                // Texture[0] has constant influence
                //splatWeights[0] = 0.5f;

                // Texture[1] is stronger at lower altitudes
                //splatWeights[0] = Mathf.Clamp01((terrainData.heightmapResolution - height));

                // Texture[2] stronger on flatter terrain
                // Note "steepness" is unbounded, so we "normalise" it by dividing by the extent of heightmap height and scale factor
                // Subtract result from 1.0 to give greater weighting to flat surfaces
                // splatWeights[0] = 1.0f - Mathf.Clamp01(steepness * steepness / (terrainData.heightmapResolution / 5.0f));
                // Texture[3] increases with height but only on surfaces facing positive Z axis 
                //splatWeights[3] = height * Mathf.Clamp01(normal.z);


                if (map.Sedimentation[y, x] > 1)
                {
                    splatWeights[0] = 1f;
                }
                else
                    splatWeights[0] = (float)map.Sedimentation[y, x];

                splatWeights[1] = 0.2f;


                // Sum of all textures weights must add to 1, so calculate normalization factor from sum of weights
                float z = splatWeights.Sum();

                // Loop through each terrain texture
                for (int i = 0; i < terrainData.alphamapLayers; i++)
                {

                    // Normalize so that sum of all texture weights = 1
                    splatWeights[i] /= z;

                    // Assign this point to the splatmap array
                    splatmapData[x, y, i] = splatWeights[i];
                }
            }
        }

        // Finally assign the new splatmap to the terrainData:
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }
}
