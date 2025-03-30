using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float BlastPower = 25;
    public float Xrotate = 0;
    public float Yrotate = 0;
    public float GameScore = 0; // increase by 1 if hit blue target
    public float ShotCount = 10; // increase by 3 if hit green target
    public GameObject Cannonball;
    public Transform ShotPoint;

    

    private void Update()
    {
        
        float HorizontalRotation = Input.GetAxis("Horizontal"); // A or D / Left or Right
        float VerticalRotation = -Input.GetAxis("Vertical"); // W or S / Up or Down

        Xrotate = Mathf.Clamp((Xrotate += (HorizontalRotation*rotationSpeed)), -90, 90);
        Yrotate = Mathf.Clamp((Yrotate += (VerticalRotation*rotationSpeed)), -60, 40);


        if (Input.GetKeyDown(KeyCode.Q))
        {
            BlastPower -= 5;
            if (BlastPower < 0)
            {
                BlastPower = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            BlastPower += 5;
            if (BlastPower > 50)
            {
                BlastPower = 50;
            }
        }


        



        transform.rotation = Quaternion.Euler(new Vector3(0, Xrotate+90, Yrotate));


        //Fire
        if (Input.GetKeyDown(KeyCode.Space) && ShotCount > 0)
        {
            ShotCount -= 1;
            print($"Shots = {ShotCount}");
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.tag = "Ball";
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            Destroy(CreatedCannonball, 10);

        }
    } 
}
