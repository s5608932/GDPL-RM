using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 25;
    public int ShotCount = 10;

    public GameObject Cannonball;
    public Transform ShotPoint;

    private void Update()
    {
        
        float HorizontalRotation = Input.GetAxis("Horizontal"); // A or D / Left or Right
        float VerticalRotation = Input.GetAxis("Vertical"); // W or S / Up or Down

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


        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed));


        //Fire
        if (Input.GetKeyDown(KeyCode.Space) && ShotCount > 0)
        {
            ShotCount -= 1;
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.tag = "Ball";
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            Destroy(CreatedCannonball, 10);
        }





    }

}
