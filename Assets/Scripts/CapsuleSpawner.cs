using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    /// 
    /// 
    /// WELCOME TO THE CAPSULESPAWNER SCRIPT
    /// THIS IS WHERE CAPSULES, PLATFORMS, AND CUBES ARE SPAWNED IN AT THE START OF A LEVEL
    /// THIS SCRIPT IS MODULAR AND CAN BE USED FOR MORE ADVANCED LEVELS, WITH THE ADDITION OF REPEATED CODE
    ///     -FOR EXAMPLE: LEVEL 2
    ///         -LEVEL 2 USES THIS SAME CODE, WITH THE ADDITION OF EXTRA GAMEOBJECTS TO CREATE MORE PLATFORMS
    /// 
    /// 




    //CAPSULES - ANY ADDITIONAL TYPE OF CAPSULE GAMEOBJECT SHOULD BE ADDED HERE
    public GameObject GreenCapsule;
    public GameObject BlueCapsule;

    //PLATFORMS - CREATE PLATFORMS HERE, ADDITIONAL PLATFORMS WILL REQUIRE THEIR OWN PREFAB - 5 PLATFORMS HAVE BEEN MADE SO FAR
    public GameObject PlatformRight;
    public GameObject PlatformMiddle;
    public GameObject PlatformLeft;

    //OBSTACLES - OBSTACLES CAN BE ADDED TO SPAWN AFTER THE PLATFORMS AND BEFORE THE CAPSULES - SO FAR ONLY THE CUBE EXISTS
    public GameObject Obstacle;

    ////An arrary of Platform Numbers for easier Cube spawning
    public Vector3[] PlatformNum = new Vector3[3];

    void Start()
    {

        //Platform Spawn Positions ( x , y , z )
        Vector3 randomSpawnRight = new Vector3(Random.Range(10, 50), Random.Range(-10, 11), Random.Range(30, 60));
        Vector3 randomSpawnMiddle = new Vector3(0, Random.Range(-5, 6), Random.Range(50, 80));
        Vector3 randomSpawnLeft = new Vector3(Random.Range(-50, -10), Random.Range(-10, 11), Random.Range(30, 60));

        //Spawn Platforms
        Instantiate(PlatformRight, randomSpawnRight, Quaternion.identity);
        Instantiate(PlatformMiddle, randomSpawnMiddle, Quaternion.identity);
        Instantiate(PlatformLeft, randomSpawnLeft, Quaternion.identity);

        //Assign Platform Array postition for cube spawning
        PlatformNum[0] = randomSpawnRight;
        PlatformNum[1] = randomSpawnMiddle;
        PlatformNum[2] = randomSpawnLeft;





        // CUBE SPAWNING
        // TO INCREASE THE AMOUNT OF CUBES PER PLATFORM, COPY AND PASTE BOTH THE [Vector3] AND [Instantiate] LINES, CHANGE SpawnCube[num] AS REQUIRED
        // CAPSULES ARE SPAWNED AT A RANDOM LOCATION FROM PLATFORM RADIUS




        //Spawn 3 Cubes per platform
        for (int i = 0; i < 3; i++)
        {
            Vector3 SpawnCube1 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube1, Quaternion.identity);
            Vector3 SpawnCube2 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube2, Quaternion.identity);
            Vector3 SpawnCube3 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube3, Quaternion.identity);
        }




        // CAPSULE SPAWNING
        // CAPSULES ARE SPAWNED PER PLATFORM
        // [CHANGE i VALUE FOR MORE CAPSULES, WILL SPAWN ONE OF EACH COLOUR PER LOOP]
        // SET THE PLATFORM USING THE PLATFORMS AND VECTORS CREATED ABOVE


        //Capsules - Left - 2 Green, 2 Blue
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomSpawnGreen = new Vector3(Random.Range(randomSpawnLeft.x-8, randomSpawnLeft.x+8) , randomSpawnLeft.y+5, Random.Range(randomSpawnLeft.z-8, randomSpawnLeft.z+ 8));
            Vector3 randomSpawnBlue = new Vector3(Random.Range(randomSpawnLeft.x - 8, randomSpawnLeft.x + 8) , randomSpawnLeft.y + 5, Random.Range(randomSpawnLeft.z - 8, randomSpawnLeft.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreen, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlue, Quaternion.identity);
        }

        //Capsules - Mid - 1 Green, 1 Blue
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomSpawnGreen = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 5, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            Vector3 randomSpawnBlue = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 5, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreen, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlue, Quaternion.identity);
        }

        //Capsules - Right - 2 Green, 2 Blue
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomSpawnGreen = new Vector3(Random.Range(randomSpawnRight.x - 8, randomSpawnRight.x + 8), randomSpawnRight.y + 5, Random.Range(randomSpawnRight.z - 8, randomSpawnRight.z + 8));
            Vector3 randomSpawnBlue = new Vector3(Random.Range(randomSpawnRight.x - 8, randomSpawnRight.x + 8), randomSpawnRight.y + 5, Random.Range(randomSpawnRight.z - 8, randomSpawnRight.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreen, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlue, Quaternion.identity);
        }
    }
}
