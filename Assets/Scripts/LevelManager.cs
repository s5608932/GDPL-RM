using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CannonController cannonController;
    public HitCapsule hitCapsule;
    string sceneName;
    public DrawProjection drawProjection;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //If the player presses "Esc" then the application will close
        {
            print("Quit"); //Print for Debug testing
            Application.Quit();
        }



        if (sceneName == "Level1") // Level 1 Win Conditions
        {
            if (cannonController.GameScore >= 5) //If the score is 5 or greater, then Level 2 will load
            {
                SceneManager.LoadScene("Level2");
            }

            if (cannonController.ShotCount == 0 && cannonController.shotActive == false && cannonController.GameScore < 5) //If the player runs out of shots, and the last ball fired has despawned - the Lose screen will appear
            {
                SceneManager.LoadScene("Lose");
                
            }
        }
        else if (sceneName == "Level2")
        {
            if (cannonController.GameScore >= 5) //If the score is 5 or greater, then Level 3 will load
            {
                SceneManager.LoadScene("Level3");
            }

            if (cannonController.ShotCount == 0 && cannonController.shotActive == false && cannonController.GameScore < 5) //If the player runs out of shots, and the last ball fired has despawned - the Lose screen will appear
            {
                SceneManager.LoadScene("Lose");

            }
        }
        else if (sceneName == "Level3")
        {
            drawProjection.renderOn = false;
            if (hitCapsule.win == true && cannonController.shotActive == false) //If the score is 1 or greater, then the Win screen will load
            {
                SceneManager.LoadScene("Win");
            }

            if (cannonController.ShotCount == 0 && cannonController.shotActive == false && cannonController.GameScore < 1) //If the player runs out of shots, and the last ball fired has despawned - the Lose screen will appear
            {
                SceneManager.LoadScene("Lose");

            }
        }



    }
}
