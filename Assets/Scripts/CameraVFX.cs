using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVFX : MonoBehaviour
{

    public CannonController cannonController;
    public float shakeDuration = 0.5f;
    public AnimationCurve intensityCurve;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && cannonController.ShotCount > 0)
        {
            StartCoroutine(Shake());

        }
    }


    IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float shakeStrength = intensityCurve.Evaluate(elapsedTime/shakeDuration);
            transform.position = startPosition + (Random.insideUnitSphere * shakeStrength);
            yield return null;

        }

        transform.position = startPosition; 
    }


}
