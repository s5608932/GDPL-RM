using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    public GameObject GreenCapsule;
    public GameObject BlueCapsule;

    public GameObject PlatformRight;
    public GameObject PlatformMiddle;
    public GameObject PlatformLeft;

    public GameObject Obstacle;

    public Vector3[] PlatformNum = new Vector3[3];

    void Start()
    {
        //Platforms
        Vector3 randomSpawnRight = new Vector3(30, Random.Range(-10, 11), 50);
        Vector3 randomSpawnMiddle = new Vector3(0, Random.Range(-5, 6), 75);
        Vector3 randomSpawnLeft = new Vector3(-30, Random.Range(-10, 11), 50);

        Instantiate(PlatformRight, randomSpawnRight, Quaternion.identity);
        Instantiate(PlatformMiddle, randomSpawnMiddle, Quaternion.identity);
        Instantiate(PlatformLeft, randomSpawnLeft, Quaternion.identity);

        PlatformNum[0] = randomSpawnRight;
        PlatformNum[1] = randomSpawnMiddle;
        PlatformNum[2] = randomSpawnLeft;
        

        //SpawnCubes
        for (int i = 0; i < 3; i++)
        {
            Vector3 SpawnCube1 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 2, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube1, Quaternion.identity);
            Vector3 SpawnCube2 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 2, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube2, Quaternion.identity);
            Vector3 SpawnCube3 = new Vector3(Random.Range(PlatformNum[i].x - 8, PlatformNum[i].x + 8), PlatformNum[i].y + 2, Random.Range(PlatformNum[i].z - 8, PlatformNum[i].z + 8));
            Instantiate(Obstacle, SpawnCube3, Quaternion.identity);
        }
        

        //Capsules - Left - 2 Green, 2 Blue
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomSpawnGreen = new Vector3(Random.Range(randomSpawnLeft.x-8, randomSpawnLeft.x+8) , randomSpawnLeft.y+2, Random.Range(randomSpawnLeft.z-8, randomSpawnLeft.z+ 8));
            Vector3 randomSpawnBlue = new Vector3(Random.Range(randomSpawnLeft.x - 8, randomSpawnLeft.x + 8) , randomSpawnLeft.y + 2, Random.Range(randomSpawnLeft.z - 8, randomSpawnLeft.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreen, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlue, Quaternion.identity);
        }

        //Capsules - Mid - 1 Green, 1 Blue
        for (int i = 0; i < 1; i++)
        {
            Vector3 randomSpawnGreen = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 2, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            Vector3 randomSpawnBlue = new Vector3(Random.Range(randomSpawnMiddle.x - 8, randomSpawnMiddle.x + 8), randomSpawnMiddle.y + 2, Random.Range(randomSpawnMiddle.z - 8, randomSpawnMiddle.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreen, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlue, Quaternion.identity);
        }

        //Capsules - Right - 2 Green, 2 Blue
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomSpawnGreen = new Vector3(Random.Range(randomSpawnRight.x - 8, randomSpawnRight.x + 8), randomSpawnRight.y + 2, Random.Range(randomSpawnRight.z - 8, randomSpawnRight.z + 8));
            Vector3 randomSpawnBlue = new Vector3(Random.Range(randomSpawnRight.x - 8, randomSpawnRight.x + 8), randomSpawnRight.y + 2, Random.Range(randomSpawnRight.z - 8, randomSpawnRight.z + 8));
            Instantiate(GreenCapsule, randomSpawnGreen, Quaternion.identity);
            Instantiate(BlueCapsule, randomSpawnBlue, Quaternion.identity);
        }
    }
}
