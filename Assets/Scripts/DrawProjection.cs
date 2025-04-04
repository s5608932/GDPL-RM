using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{

    //THIS SCRIPT IS WHERE THE SHOT PROJECTION LINE IS CREATED



    //--DO NOT TOUCH -- IT WORKS :)
    
    


    CannonController cannonController;
    LineRenderer lineRenderer;
    //Number of points on line
    public int numPoints = 50;
    //Distance between points
    public float distPoints = 0.1f;

    public LayerMask CollidableLayers;

    void Start()
    {
        cannonController = GetComponent<CannonController>();
        lineRenderer = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        //EVERY UPDATE, THE LINE WILL BE CREATED BASED OFF THE TRAJECTORY OF THE BALL
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = cannonController.ShotPoint.position;
        Vector3 startingVelocity = cannonController.ShotPoint.up * cannonController.BlastPower;

        for (float t = 0; t < numPoints; t += distPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }
}
