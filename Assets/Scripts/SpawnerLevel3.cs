using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel3 : MonoBehaviour
{

    /// WELCOME TO THE SPAWNER SCRIPT FOR LEVEL 3
    /// LEVEL 3 ONLY HAS ONE PLATFORM AND ONE CAPSULE (RED)
    /// HIT THE RED CAPSULE TO WIN THE GAME
    /// PLAYER ONLY HAS 1 SHOT AND NO PROJECTION LINE
    /// PLATFORM AND CAPSULE HAVE A SET SPAWN POSITION


    public GameObject RedCapsule;
    public GameObject Obstacle;
    public GameObject PlatformMiddle; // Middle Platform
    
    void Start()
    {
        //Platform Spawn Positions ( x , y , z )
        Vector3 randomSpawnMiddle = new Vector3(0, Random.Range(-5, 6), Random.Range(50, 80));
        
        //Spawn Platforms
        Instantiate(PlatformMiddle, randomSpawnMiddle, Quaternion.identity);
        
        Vector3 SpawnCube1 = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 1, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
        Instantiate(Obstacle, SpawnCube1, Quaternion.identity);
        Vector3 SpawnCube2 = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 1, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
        Instantiate(Obstacle, SpawnCube2, Quaternion.identity);
        

        Vector3 randomSpawnRed = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 5, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
        var RandomMoveRed = Instantiate(RedCapsule, randomSpawnRed, Quaternion.identity);     
    }
}
