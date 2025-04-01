using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{

    //THIS SCRIPT WILL DESTROY OBJECTS WHEN THEY FALL OFF THE PLATFORMS, AND COLLIDE WITH AN "EXIT CUBE"



    public CannonController cannonController; 
             

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ball") || (other.gameObject.CompareTag("Obstacle"))) //THIS DESTROYS EITHER A BALL OR CUBE WHEN IT FALLS OFF THE MAP
        {
            Destroy(other.gameObject);
        }




        //IF A CAPSULE FALLS OFF THE MAP, WHETHER IT ROLLS OFF OR GETS KNOCKED OFF, THE BONUS IS STILL GIVEN

        if (other.gameObject.CompareTag ("GreenCapsule")) //GREEN CAPSULE AWARDS 3 EXTRA SHOTS
        {
            Destroy(other.gameObject); //DESTROY THE CAPSULE
            cannonController.ShotCount += 3;
            print($"Shots = {cannonController.ShotCount}"); //PRINT TO DEBUG LOG
        }


        if (other.gameObject.CompareTag ("BlueCapsule")) //BLUE CAPSULE AWARDS 1 GAMESCORE
        {
            Destroy(other.gameObject); //DESTROY THE CAPSULE
            cannonController.GameScore += 1;
            print($"Score = {cannonController.GameScore}"); //PRINT TO DEBUG LOG
        }
    }

}
