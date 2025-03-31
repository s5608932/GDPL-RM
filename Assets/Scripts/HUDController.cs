using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{

    public CannonController cannonController;


    public TextMeshProUGUI rotationTXT;
    public TextMeshProUGUI elevationTXT;

    private void Update()
    {
        var minusElevation = -cannonController.Yrotate;
        rotationTXT.text = "Rotation : " + cannonController.Xrotate.ToString("F0");
        elevationTXT.text = "Elevation : " + minusElevation.ToString("F0");
    }

}
