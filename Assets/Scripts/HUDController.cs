using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{

    //THE FOLLOWING SCRIPT WILL CONTROL THE UI
    //THIS IS WHERE INPUTS ARE ASSIGNED FROM THE CANNON
    //THIS IS ALSO WHERE WIN OR LOSE LOGIC TAKES PLACE


    public CannonController cannonController; //This Script is needed for the different variables to be read 

    //The following will allow text to be entered onto the UI
    public TextMeshProUGUI rotationTXT;
    public TextMeshProUGUI elevationTXT;
    public TextMeshProUGUI powerTXT;
    public TextMeshProUGUI shotsTXT;
    public TextMeshProUGUI scoreTXT;
    public TextMeshProUGUI rotationSpeedTXT;
    

    private void Update()
    {
        var minusElevation = -cannonController.Yrotate; //Flips the rotation values for the cannon - this corrects it.
        var displayPower = cannonController.BlastPower / 5; // Turns the BlastPower value into a 1-10 scale
        var displayRotation = cannonController.rotationSpeed / 10; // Turns the RotationSpeed value into a 1-10 scale

        //The following seciton will enter the text to be displayed on the UI
        rotationTXT.text = "Rotation : " + cannonController.Xrotate.ToString("F0");
        elevationTXT.text = "Elevation : " + minusElevation.ToString("F0");
        powerTXT.text = "Power : " + displayPower.ToString("F0");
        shotsTXT.text = "Shots : " + cannonController.ShotCount.ToString("F0");
        scoreTXT.text = "Score : " + cannonController.GameScore.ToString("F0");
        rotationSpeedTXT.text = "Rotation Speed : " + displayRotation.ToString("F0");

        if (cannonController.GameScore >= 5) //If the score is 5 or greater, then Level 2 will load
        {
            SceneManager.LoadScene("Level2");
        }

        if (cannonController.ShotCount == 0 && cannonController.shotActive == false) //If the player runs out of shots, and the last ball fired has despawned - the Lose screen will appear
        {
            if (cannonController.GameScore < 5)
            {
                SceneManager.LoadScene("Lose");
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Escape)) //If the player presses "Esc" then the application will close
        {
            print("Quit"); //Print for Debug testing
            Application.Quit();
        }
        
    }

}
