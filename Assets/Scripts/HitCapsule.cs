using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCapsule : MonoBehaviour
{

    //THIS SCRIPT IS USED WHEN THE BALL COLLIDES WITH ONE OF THE CAPSULES
    //HITTING A GREEN CAPSULE INCREASES THE SHOTCOUNT BY 3
    //HITTING A BLUE CAPSULE INCREASES THE SCORE BY 1


    public CannonController cannonController; //USED FOR SCORE AND SHOTCOUNT VALUES
    public bool greenHit = false;
    public bool blueHit = false;


    private void Start()
    {
        cannonController = FindObjectOfType<CannonController>();
    }





    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("GreenCapsule"))
        {
            greenHit = true;
            Destroy(other.gameObject);
            cannonController.ShotCount += 3;
            //print($"Shots + 3 = {cannonController.ShotCount}");
            greenHit = false;
        }


        if (other.gameObject.tag == ("BlueCapsule"))
        {
            blueHit = true;
            Destroy(other.gameObject);
            cannonController.GameScore += 1;
            //print($"Score = {cannonController.GameScore}");
            blueHit = false;
        }
    }

}
