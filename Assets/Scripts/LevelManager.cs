using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CannonController cannonController;
    public HitCapsule hitCapsule;
    private string sceneName;
    
    
    /*
        LEVEL MANAGER SCRIPT 
        THIS SCRIPT IS WHERE WIN CONDITIONS CAN BE DEFINED (CHANGING GAMESCORE IN IF STATEMENTS)
        THIS IS WHERE THE NEXT LEVEL IS LOADED
      
    */
    void Start()
    {
        cannonController = FindObjectOfType<CannonController>();
        

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
            //WIN HANDLED WHEN CAPSULE IS HIT - "HitCapsule.cs" Script

            //LOSE
            if (cannonController.shotActive == false && cannonController.ShotCount == 0) //If the ball fired has despawned - the Lose screen will appear
            {
                SceneManager.LoadScene("Lose");

            }
        }
    }
}
