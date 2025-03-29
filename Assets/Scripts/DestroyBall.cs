using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{

    public CannonController Shots;
             

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ball") || (other.gameObject.CompareTag("Obstacle")))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag ("GreenCapsule"))
        {
            Destroy(other.gameObject);
            Shots.ShotCount += 3;
            print($"Shots = {Shots.ShotCount}");
        }


        if (other.gameObject.CompareTag ("BlueCapsule"))
        {
            Destroy(other.gameObject);
            Shots.GameScore += 1;
            print($"Score = {Shots.GameScore}");
        }
    }

}
