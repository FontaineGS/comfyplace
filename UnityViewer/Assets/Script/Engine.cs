using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CV.World;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

public class Engine : MonoBehaviour
{

    public CompleteWorld World { get; set; }
    // Start is called before the first frame update

    public Task Job = null;
    void Start()
    {
        // TODO: Add your initialization logic here
        WorldGenerator generator = new WorldGenerator();
        Stopwatch chrono = new Stopwatch();
        chrono.Start();
        var _world = generator.GenerateWorldTerrain();
        generator.Populate(_world);
        var _resolver = new WorldResolver();
        _resolver.World = _world;
        World = _world;
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void UpdateTerrain()
    {
        
        Job = Task.Run(() => World.Terrain.Erode(10000));


       // World.Terrain.Erode(10000);
    }

    
}
