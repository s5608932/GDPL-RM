using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float BlastPower = 25;
    public float Xrotate = 0;
    public float Yrotate = 0;
    public float GameScore = 0; // increase by 1 if hit blue target
    public float ShotCount = 10; // increase by 3 if hit green target
    public GameObject Cannonball;
    public Transform ShotPoint;
    public bool shotActive = false;

    private void Update()
    {
       
        //THIS SCRIPT IS WHERE THE CANNON IS CONTROLLED
        //ROTATIONS, POWER, AND FIRE BUTTON ARE ALL SET WITH CLAMPS
        //COROUTINE USED TO DESPAWN THE BALL AFTER 10 SECONDS - for lose screen to appear

        float HorizontalRotation = Input.GetAxis("Horizontal"); // A or D / Left or Right
        float VerticalRotation = -Input.GetAxis("Vertical"); // W or S / Up or Down

        //ROTATION SPEED INPUT - PRESS I AND O TO DECREASE / INCREASE THE ROTATION SPEED
        if (Input.GetKeyDown(KeyCode.O))
        {
            rotationSpeed += 10;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            rotationSpeed -= 10;
        }
        rotationSpeed = Mathf.Clamp(rotationSpeed, 10, 100);//THIS CLAMP PREVENTS THE ROTATION SPEED FROM BEING SET TOO HIGH OR LOW

        // THESE CLAMPS SET THE ROTATION LIMITS
        Xrotate = Mathf.Clamp((Xrotate += (rotationSpeed * Time.deltaTime * HorizontalRotation )), 0, 180); //THIS CLAMPS THE HORIZONTAL ROTATION BETWEEN 0 AND 180
        Yrotate = Mathf.Clamp((Yrotate += (rotationSpeed * Time.deltaTime * VerticalRotation )), -60, 40); //THIS CLAMPS THE VERTICAL ROTATION BETWEEN -60 AND 40 - BE CAREFUL ROTATING CANNON MODEL / PREFAB


        //BLAST POWER INPUT - PRESS Q AND E TO DECREASE / INCREASE THE BLAST POWER OF THE CANNON
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BlastPower -= 5;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BlastPower += 5;
        }
        BlastPower = Mathf.Clamp(BlastPower, 0, 50); //THIS CLAMP PREVENTS THE BLAST POWER BECOMMING TOO POWERFUL / ALSO PREVENTS NEGATIVE POWER

        // THIS SETS THE ROTATION OF THE CANNON OBJECT BASED ON THE ROTATIONS SET
        transform.rotation = Quaternion.Euler(new Vector3(0, Xrotate, Yrotate));


        //FIRE - PRESS THE "SPACE" KEY TO FIRE THE CANNON
        //A COROUTINE IS SET UP TO ALLOW THE FINAL SHOT TO LAST A FULL 10 SECONDS BEFORE THE LOSE SCREEN APPEARS - THIS ALLOWS ANY LAST SECOND ROLLS INTO HITTING A TARGET TO INCREASE SHOT COUNT
        if (Input.GetKeyDown(KeyCode.Space) && ShotCount > 0)
        {
            StopAllCoroutines();
            shotActive = true;
            ShotCount -= 1;
            print($"Shots = {ShotCount}"); //PRINT TO LOG FOR DEBUG TESTING

            //THIS CREATES A CANNONBALL - LOCATED AT THE SHOT POINT - AND TAGS IT
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.tag = "Ball";
            
            //THIS FIRES THE BALL BASED ON THE CANNON ROTATION AND THE BLAST POWER SET
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            Destroy(CreatedCannonball, 10); //THIS WILL DESTROY THE CANNONBALL AFTER 10 SECONDS
            StartCoroutine(shotDeactivate()); //THIS WILL ACTIVATE A COROUTINE FOR ACTIVATING THE LOSE SCREEN
        }
        
        
    } 

    private IEnumerator shotDeactivate() //COROUTINE TO ALLOW ANY LAST SECOND ROLLS INTO HITTING A TARGET TO INCREASE SHOT COUNT - ENABLES THE SHOTCOUNT TO BE 0 WITHOUT IMMEDIATELY GOING TO A LOSE SCREEN
    {
        yield return new WaitForSecondsRealtime(10);
        shotActive = false;
    }
}
