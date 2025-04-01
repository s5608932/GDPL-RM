using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    public GameObject GreenCapsule;
    public GameObject BlueCapsule;

    public GameObject PlatformRight;
    public GameObject PlatformMiddle;
    public GameObject PlatformLeft;

    public GameObject Obstacle;

    public CannonController cannonController;
    public GameObject Visualcannonball;
    public GameObject visStartSpawner;

    public Vector3[] PlatformNum = new Vector3[3];

    void Start()
    {



        //VisualCannonballs
        //Spawn cannonballs at start of level
        float VisShotCount = cannonController.ShotCount;
        

        
        for (int i = 0; i < VisShotCount; i++)
        {
            float randOffset = Random.Range(-2, 2);
            Vector3 offSetSpawn = visStartSpawner.transform.position;
            offSetSpawn.x += randOffset;
            offSetSpawn.y += randOffset;
            offSetSpawn.z += randOffset;
            Instantiate(Visualcannonball, offSetSpawn, Quaternion.identity);
        }








        //Platforms
        Vector3 randomSpawnRight = new Vector3(Random.Range(10, 50), Random.Range(-10, 11), Random.Range(30, 60));
        Vector3 randomSpawnMiddle = new Vector3(0, Random.Range(-5, 6), Random.Range(50, 80));
        Vector3 randomSpawnLeft = new Vector3(Random.Range(-50, -10), Random.Range(-10, 11), Random.Range(30, 60));

        Instantiate(PlatformRight, randomSpawnRight, Quaternion.identity);
        Instantiate(PlatformMiddle, randomSpawnMiddle, Quaternion.identity);
        Instantiate(PlatformLeft, randomSpawnLeft, Quaternion.identity);

        PlatformNum[0] = randomSpawnRight;
        PlatformNum[1] = randomSpawnMiddle;
        PlatformNum[2] = randomSpawnLeft;
        

        //SpawnCubes
        for (int i = 0; i < 3; i++)
        {
            Vector3 SpawnCube1 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube1, Quaternion.identity);
            Vector3 SpawnCube2 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube2, Quaternion.identity);
            Vector3 SpawnCube3 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 1, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube3, Quaternion.identity);
        }

        

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
