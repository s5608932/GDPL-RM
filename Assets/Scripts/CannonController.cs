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
       
        float HorizontalRotation = Input.GetAxis("Horizontal"); // A or D / Left or Right
        float VerticalRotation = -Input.GetAxis("Vertical"); // W or S / Up or Down

        if (Input.GetKeyDown(KeyCode.O))
        {
            rotationSpeed += 10;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            rotationSpeed -= 10;
        }

        rotationSpeed = Mathf.Clamp(rotationSpeed, 10, 100);

        Xrotate = Mathf.Clamp((Xrotate += (rotationSpeed * Time.deltaTime * HorizontalRotation )), 0, 180);
        Yrotate = Mathf.Clamp((Yrotate += (rotationSpeed * Time.deltaTime * VerticalRotation )), -60, 40);


        if (Input.GetKeyDown(KeyCode.Q))
        {
            BlastPower -= 5;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            BlastPower += 5;
        }
        BlastPower = Mathf.Clamp(BlastPower, 0, 50);

        transform.rotation = Quaternion.Euler(new Vector3(0, Xrotate, Yrotate));


        //Fire
        if (Input.GetKeyDown(KeyCode.Space) && ShotCount > 0)
        {
            StopAllCoroutines();
            shotActive = true;
            ShotCount -= 1;
            print($"Shots = {ShotCount}");
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.tag = "Ball";
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            Destroy(CreatedCannonball, 10);
            StartCoroutine(shotDeactivate());
        }
        
        
    } 

    private IEnumerator shotDeactivate()
    {
        yield return new WaitForSecondsRealtime(10);
        shotActive = false;
    }
}
