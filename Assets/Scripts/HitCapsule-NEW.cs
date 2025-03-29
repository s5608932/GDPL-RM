using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCapsule : MonoBehaviour
{
    
    public CannonController Shots;   
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("GreenCapsule"))
        {
            Destroy(other.gameObject);
            Shots.ShotCount += 3;
            print($"Shots + 3 = {Shots.ShotCount}");
        }


        if (other.gameObject.tag == ("BlueCapsule"))
        {
            Destroy(other.gameObject);
            Shots.GameScore += 1;
            print($"Score = {Shots.GameScore}");
        }
    }

}
