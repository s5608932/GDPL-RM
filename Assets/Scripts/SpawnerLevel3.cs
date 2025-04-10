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


    //CAPSULES - ANY ADDITIONAL TYPE OF CAPSULE GAMEOBJECT SHOULD BE ADDED HERE
    public GameObject RedCapsule;

    //OBSTACLES - OBSTACLES CAN BE ADDED TO SPAWN AFTER THE PLATFORMS AND BEFORE THE CAPSULES - SO FAR ONLY THE CUBE EXISTS
    public GameObject Obstacle;

    //PLATFORM - CREATE PLATFORMS HERE - ADDITIONAL PLATFORMS WILL REQUIRE THEIR OWN PREFAB, 5 HAVE BEEN MADE SO FAR
    public GameObject PlatformMiddle; // Middle Platform
    
    //AN ARRAY OF PLATFORM NUMBERS FOR EASIER CUBE SPAWNING - CHANGE THE [5] TO CHANGE HOW MANY PLATFORMS
    public Vector3[] PlatformNum = new Vector3[1];

    

    void Start()
    {
        //Platform Spawn Positions ( x , y , z )
        Vector3 randomSpawnMiddle = new Vector3(0, Random.Range(-5, 6), Random.Range(50, 80));
        

        //Spawn Platforms
        Instantiate(PlatformMiddle, randomSpawnMiddle, Quaternion.identity);
        

        //Assign Platform Array postition for cube spawning
        
        PlatformNum[0] = randomSpawnMiddle;
        

        // CUBE SPAWNING
        // TO INCREASE THE AMOUNT OF CUBES PER PLATFORM, COPY AND PASTE BOTH THE [Vector3] AND [Instantiate] LINES, CHANGE SpawnCube[num] AS REQUIRED
        // CAPSULES ARE SPAWNED AT A RANDOM LOCATION FROM PLATFORM RADIUS

        //Spawn 2 Cubes on platform
        for (int i = 0; i < 1; i++)
        {
            Vector3 SpawnCube1 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube1, Quaternion.identity);
            Vector3 SpawnCube2 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube2, Quaternion.identity);
        }

        // CAPSULE SPAWNING
        // 1 RED CAPSULE IS SPAWNED, HIT THIS TO WIN

        //Capsules - Mid - 1 Red
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomSpawnRed = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 5, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            var RandomMoveRed = Instantiate(RedCapsule, randomSpawnRed, Quaternion.identity);
            
        }
                
    }
}
