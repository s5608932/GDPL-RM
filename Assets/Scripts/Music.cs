using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSFX : MonoBehaviour
{

    
    public AudioSource BG1;
    public AudioSource BG2;
    public int trackPlaying;
    void Start()
    {
        trackPlaying = (Random.Range(0, 2));
        if (trackPlaying == 0)
        {
            BG1.Play();
        }
        else if (trackPlaying == 1) 
        {
            BG2.Play();
        }
    }    
}
