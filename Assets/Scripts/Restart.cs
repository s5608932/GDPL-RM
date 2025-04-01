using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    //THIS SCRIPT IS SEEN ON THE WIN OR LOSE SCREEN
    //IT ALLOWS THE PLAYER TO EITHER RESTART THE GAME - WHICH LOADS LEVEL 1 "GDPL"
    //IT ALLOWS THE PLAYER TO EXIT THE GAME - WHICH CLOSES THE APPLICATION
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("RESTART");
            SceneManager.LoadScene("GDPL"); //GDPL IS LEVEL 1
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("QUIT");
            Application.Quit();
        }
    }
}
