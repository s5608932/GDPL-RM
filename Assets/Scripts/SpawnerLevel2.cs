using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel2 : MonoBehaviour
{

    /// WELCOME TO THE CAPSULESPAWNER SCRIPT FOR LEVEL 2
    /// THIS IS WHERE CAPSULES, PLATFORMS, AND CUBES ARE SPAWNED IN AT THE START OF A LEVEL
    /// THIS SCRIPT IS MODULAR AND CAN BE USED FOR MORE ADVANCED LEVELS, WITH THE ADDITION OF REPEATED CODE




    //CAPSULES - ANY ADDITIONAL TYPE OF CAPSULE GAMEOBJECT SHOULD BE ADDED HERE
    public GameObject GreenCapsule; 
    public GameObject BlueCapsule;

    //PLATFORM - CREATE PLATFORMS HERE, ADDITIONAL PLATFORMS WILL REQUIRE THEIR OWN PREFAB - 5 PLATFORMS HAVE BEEN MADE SO FAR
    public GameObject PlatformRight; // Far right platform
    public GameObject PlatformMR; // Middle Right Platform
    public GameObject PlatformMiddle; // Middle Platform
    public GameObject PlatformML; // Middle Left Platform
    public GameObject PlatformLeft; // Far Left Platform

    //OBSTACLES - OBSTACLES CAN BE ADDED TO SPAWN AFTER THE PLATFORMS AND BEFORE THE CAPSULES - SO FAR ONLY THE CUBE EXISTS
    public GameObject Obstacle;

    //AN ARRAY OF PLATFORM NUMBERS FOR EASIER CUBE SPAWNING - CHANGE THE [5] TO CHANGE HOW MANY PLATFORMS
    public Vector3[] PlatformNum = new Vector3[5]; 

    void Start()
    {
        //Platform Spawn Positions ( x , y , z )
        Vector3 randomSpawnRight = new Vector3(Random.Range(30, 35), Random.Range(-10, 11), Random.Range(30, 60));
        Vector3 randomSpawnMR = new Vector3(Random.Range(20, 25), Random.Range(10, 15), Random.Range(80, 100));
        Vector3 randomSpawnMiddle = new Vector3(0, Random.Range(-5, 6), Random.Range(50, 80));
        Vector3 randomSpawnML = new Vector3(Random.Range(-25, -20), Random.Range(10, 15), Random.Range(80, 100));
        Vector3 randomSpawnLeft = new Vector3(Random.Range(-35, -30), Random.Range(-10, 11), Random.Range(30, 60));

        //Spawn Platforms
        Instantiate(PlatformRight, randomSpawnRight, Quaternion.identity);
        Instantiate(PlatformMR, randomSpawnMR, Quaternion.identity);
        Instantiate(PlatformMiddle, randomSpawnMiddle, Quaternion.identity);
        Instantiate(PlatformML, randomSpawnML, Quaternion.identity);
        Instantiate(PlatformLeft, randomSpawnLeft, Quaternion.identity);

        //Assign Platform Array postition for cube spawning
        PlatformNum[0] = randomSpawnRight;
        PlatformNum[1] = randomSpawnMR;
        PlatformNum[2] = randomSpawnMiddle;
        PlatformNum[3] = randomSpawnML;
        PlatformNum[4] = randomSpawnLeft;





        // CUBE SPAWNING
        // TO INCREASE THE AMOUNT OF CUBES PER PLATFORM, COPY AND PASTE BOTH THE [Vector3] AND [Instantiate] LINES, CHANGE SpawnCube[num] AS REQUIRED
        // CAPSULES ARE SPAWNED AT A RANDOM LOCATION FROM PLATFORM RADIUS




        //Spawn 3 Cubes per platform
        for (int i = 0; i < 5; i++)
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
            Vector3 randomSpawnGreenL = new Vector3(Random.Range(randomSpawnLeft.x - 8, randomSpawnLeft.x + 8), randomSpawnLeft.y + 5, Random.Range(randomSpawnLeft.z - 8, randomSpawnLeft.z + 8));
            Vector3 randomSpawnBlueL = new Vector3(Random.Range(randomSpawnLeft.x - 8, randomSpawnLeft.x + 8), randomSpawnLeft.y + 5, Random.Range(randomSpawnLeft.z - 8, randomSpawnLeft.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreenL, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlueL, Quaternion.identity);
        }

        //Capsules - MidLeft - 1 Green, 1 Blue
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomSpawnGreenML = new Vector3(Random.Range(randomSpawnML.x - 8, randomSpawnML.x + 8), randomSpawnML.y + 5, Random.Range(randomSpawnML.z - 8, randomSpawnML.z + 8));
            Vector3 randomSpawnBlueML = new Vector3(Random.Range(randomSpawnML.x - 8, randomSpawnML.x + 8), randomSpawnML.y + 5, Random.Range(randomSpawnML.z - 8, randomSpawnML.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreenML, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlueML, Quaternion.identity);
        }


        //Capsules - Mid - 1 Green, 1 Blue
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomSpawnGreenM = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 5, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            Vector3 randomSpawnBlueM = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 5, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreenM, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlueM, Quaternion.identity);
        }


        //Capsules - MidRight - 1 Green, 1 Blue
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomSpawnGreenMR = new Vector3(Random.Range(randomSpawnMR.x - 8, randomSpawnMR.x + 8), randomSpawnMR.y + 5, Random.Range(randomSpawnMR.z - 8, randomSpawnMR.z + 8));
            Vector3 randomSpawnBlueMR = new Vector3(Random.Range(randomSpawnMR.x - 8, randomSpawnMR.x + 8), randomSpawnMR.y + 5, Random.Range(randomSpawnMR.z - 8, randomSpawnMR.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreenMR, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlueMR, Quaternion.identity);
        }

        //Capsules - Right - 2 Green, 2 Blue
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomSpawnGreenR = new Vector3(Random.Range(randomSpawnRight.x - 8, randomSpawnRight.x + 8), randomSpawnRight.y + 5, Random.Range(randomSpawnRight.z - 8, randomSpawnRight.z + 8));
            Vector3 randomSpawnBlueR = new Vector3(Random.Range(randomSpawnRight.x - 8, randomSpawnRight.x + 8), randomSpawnRight.y + 5, Random.Range(randomSpawnRight.z - 8, randomSpawnRight.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreenR, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlueR, Quaternion.identity);
        }
    }
}
