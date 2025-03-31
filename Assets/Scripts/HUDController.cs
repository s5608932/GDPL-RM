using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{

    public CannonController cannonController;

    public TextMeshProUGUI rotationTXT;
    public TextMeshProUGUI elevationTXT;
    public TextMeshProUGUI powerTXT;
    public TextMeshProUGUI shotsTXT;
    public TextMeshProUGUI scoreTXT;
    public TextMeshProUGUI rotationSpeedTXT;
    

    private void Update()
    {
        var minusElevation = -cannonController.Yrotate;
        var displayPower = cannonController.BlastPower / 5;
        var displayRotation = cannonController.rotationSpeed / 10;
        rotationTXT.text = "Rotation : " + cannonController.Xrotate.ToString("F0");
        elevationTXT.text = "Elevation : " + minusElevation.ToString("F0");
        powerTXT.text = "Power : " + displayPower.ToString("F0");
        shotsTXT.text = "Shots : " + cannonController.ShotCount.ToString("F0");
        scoreTXT.text = "Score : " + cannonController.GameScore.ToString("F0");
        rotationSpeedTXT.text = "Rotation Speed : " + displayRotation.ToString("F0");

        if (cannonController.GameScore >= 5)
        {
            SceneManager.LoadScene("Win");
        }
        if (cannonController.ShotCount == 0 && cannonController.shotActive == false)
        {
            if (cannonController.GameScore < 5)
            {
                SceneManager.LoadScene("Lose");
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Quit");
            Application.Quit();
        }
        
    }

}
