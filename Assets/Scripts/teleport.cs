using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public teleport otherTeleport;
    public bool canTeleport = true;

    public Rigidbody Ball_Physics;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Ball_Physics = other.gameObject.GetComponent<Rigidbody>();

            Ball_Physics.isKinematic = true;



            if (canTeleport == true)
            {

                


                otherTeleport.canTeleport = false;
                other.transform.position = otherTeleport.transform.position;

                Ball_Physics.isKinematic = false;
                


            }



        }



    } 
}
