using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HitCapsule : MonoBehaviour
{

    //THIS SCRIPT IS USED WHEN THE BALL COLLIDES WITH ONE OF THE CAPSULES
    //HITTING A GREEN CAPSULE INCREASES THE SHOTCOUNT BY 3
    //HITTING A BLUE CAPSULE INCREASES THE SCORE BY 1
    //HIT A RED CAPSULE TO WIN - ONLY FOUND ON L3

    public CannonController cannonController; //USED FOR SCORE AND SHOTCOUNT VALUES
    
    public bool redHit = false;

    private void Start()
    {
        cannonController = FindObjectOfType<CannonController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("GreenCapsule"))
        {
            
            Destroy(other.gameObject);
            cannonController.ShotCount += 3;
            
        }


        if (other.gameObject.tag == ("BlueCapsule"))
        {
            
            Destroy(other.gameObject);
            cannonController.GameScore += 1;
            
        }

        if (other.gameObject.tag == ("RedCapsule"))
        {
            redHit = true;
            Destroy(other.gameObject);
            SceneManager.LoadScene("Win"); // IF RED IS HIT - WIN GAME
        }
    }
}
