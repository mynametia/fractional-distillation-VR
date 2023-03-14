using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    private float yPositionWorldView, zPositionWorldView;
    public float yTopWorldView;
    private float screenRatio;
    private float targetDeviceRatio;

    public Camera viewingCamera;
    void Start()
    {
        yTopWorldView = 487 + (SliderOptionsMenu.trayNumberValue - 1) * 120 + 756.24f - 30.63f;
        yPositionWorldView = (yTopWorldView / 2) + 30.63f;
        zPositionWorldView = 2000;
        //zPositionWorldView = yTopWorldView / (2*Mathf.Tan(0.5f * viewingCamera.fieldOfView * Mathf.Deg2Rad));
        /*
        Debug.Log("y:" + yTopWorldView);
        Debug.Log("field of view half in degrees:" + 0.5f * viewingCamera.fieldOfView);
        Debug.Log("tan:" + Mathf.Tan(0.5f * viewingCamera.fieldOfView * Mathf.Deg2Rad));
        Debug.Log("z:" + zPositionWorldView);
        */

        transform.position = new Vector3(0, yPositionWorldView, zPositionWorldView);
        Debug.Log("camera position:" + transform.position);

        //set size of orthographic camera
        screenRatio = (float)Screen.width / (float)Screen.height;
        targetDeviceRatio = 1823 / yTopWorldView;
        if (screenRatio >= targetDeviceRatio)
        {
            viewingCamera.orthographicSize = yTopWorldView / 2;
        }
        else 
        {
            float sizeDiff = targetDeviceRatio - screenRatio;
            viewingCamera.orthographicSize = yTopWorldView / 2 * sizeDiff;
        }
        

    }

}
