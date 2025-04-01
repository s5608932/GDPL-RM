using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCapsule : MonoBehaviour
{

    //THIS SCRIPT IS USED WHEN THE BALL COLLIDES WITH ONE OF THE CAPSULES
    //HITTING A GREEN CAPSULE INCREASES THE SHOTCOUNT BY 3
    //HITTING A BLUE CAPSULE INCREASES THE SCORE BY 1


    public CannonController cannonController; //USED FOR SCORE AND SHOTCOUNT VALUES


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("GreenCapsule"))
        {
            print("Hit Green");
            Destroy(other.gameObject);
            

            //ERROR - GAME BREAKS WHEN TRYING TO UPDATE THE SHOTCOUNT
            cannonController.ShotCount += 3;
            print($"Shots + 3 = {cannonController.ShotCount}");
        }


        if (other.gameObject.tag == ("BlueCapsule"))
        {
            Destroy(other.gameObject);



            //ERROR - GAME BREAKS WHEN TRYING TO UPDATE THE SCORE
            cannonController.GameScore += 1;
            print($"Score = {cannonController.GameScore}");
        }
    }

}
