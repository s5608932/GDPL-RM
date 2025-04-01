using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCannonBalls : MonoBehaviour
{

    
    public GameObject Visualcannonball; //This prefab is the "Visual" Cannonballs, a seperate object to the main cannonballs, to prevent any interferance with shotcounts, scores, etc... These are purely a visual representation of the ShotCount
    public GameObject visStartSpawner; //The StartSpawner is only used when the level loads, it creates the same number of cannonballs as the shotcount, to go into the box
    public CannonController cannonController; //The CannonController Script contains Cannon Controls, as well as ShotCounts, Score, and other variables
    public GameObject visualSpawner; //This is the spawn point for the "Visual" cannonballs to spawn at, when the shotCount increases, these will then roll down the small ramp, then into the box
    public List<GameObject> visBallList = new List<GameObject>(); //This is a list to store the "active" visualCannonballs

    //THIS SCRIPT CONTAINS THE CODE TO SPAWN AND DELETE THE VISUALCANNONBALLS,
    //THESE ARE SEEN IN THE CRATE NEXT TO THE CANNON,
    //THEY SHOW THE AMOUNT OF SHOTS REMAINING FOR THE PLAYER

    void Start()
    {

        //Spawn cannonballs at start of level
        float VisShotCount = cannonController.ShotCount;
        //creates 10 balls at start - add to list
        for (int i = 0; i < VisShotCount; i++)
        {
            float randOffset = Random.Range(-1, 1);
            Vector3 offSetSpawn = visStartSpawner.transform.position;
            offSetSpawn.x += randOffset;
            offSetSpawn.y += randOffset;
            offSetSpawn.z += randOffset;
            Instantiate(Visualcannonball, offSetSpawn, Quaternion.identity);
            visBallList.Add(Visualcannonball);
        }
    }


    void Update()
    {
        //Check whether List of visualCannonballs is equal to ShotCount
        //If cannon fires, shot count goes down by 1, so visualCannonball should be deleted
        //If Green Capsule is hit or falls off, the shot count increases by 3, so 3 new visualCannonballs need to be spawned / added to list
        float VisShotCount = cannonController.ShotCount;


        if (visBallList.Count > cannonController.ShotCount)
        {
            visBallList.Remove(Visualcannonball);
            
        }

        if (visBallList.Count < cannonController.ShotCount)
        {
            visBallList.Add(Visualcannonball);
            Vector3 spawnLoc = visualSpawner.transform.position;
            Instantiate(Visualcannonball, spawnLoc, Quaternion.identity);
            visBallList.Add(Visualcannonball);

        }
    }
}
