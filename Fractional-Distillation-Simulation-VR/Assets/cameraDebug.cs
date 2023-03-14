using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraDebug : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("camera far clipping plane: " + cam.farClipPlane);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
