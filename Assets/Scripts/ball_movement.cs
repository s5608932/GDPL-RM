using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ball_movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public Vector3 shotDirection;



    // Update is called once per frame
    void Update()
    {


        //Up and Down Aim
        if (Input.GetKeyDown(KeyCode.W))
        {
            shotDirection.y += 1f;

            if (shotDirection.y > 90)
            {
                shotDirection.y = 90;
            }
            UnityEngine.Debug.Log("Elevation = " + shotDirection.y);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            shotDirection.y += -1f;

            if (shotDirection.y < 0)
            {
                shotDirection.y = 0;
            }
            UnityEngine.Debug.Log("Elevation = " + shotDirection.y);
        }



        //Left and Right Aim
        if (Input.GetKeyDown(KeyCode.A))
        {
            shotDirection.x += -1f;

            if (shotDirection.x < -90)
            {
                shotDirection.x = -90;
            }

            UnityEngine.Debug.Log("Rotation = " + shotDirection.x);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            shotDirection.x += +1f;

            if (shotDirection.x > 90)
            {
                shotDirection.x = 90;
            }
            UnityEngine.Debug.Log("Rotation = " + shotDirection.x);
        }


        //Power
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shotDirection.z += -1f;

            if (shotDirection.z < 0)
            {
                shotDirection.z = 0;
            }
            UnityEngine.Debug.Log("Power = " + shotDirection.z);
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            shotDirection.z += +1f;

            if (shotDirection.z > 10)
            {
                shotDirection.z = 10;
            }

            UnityEngine.Debug.Log("Power = " + shotDirection.z);
            

        }


        //Launch Button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(shotDirection.normalized * speed);
        }



        //Draw Shot Direction on Scene View / Not Game View.
        UnityEngine.Debug.DrawRay(transform.position, shotDirection.normalized * speed, Color.red);


        
    }
}
