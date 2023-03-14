using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIfaceCamera : MonoBehaviour
{
    public Camera cameraToLookAt;

    void Start()
    {
        cameraToLookAt = Camera.main;
        transform.LookAt(cameraToLookAt.transform.position);
        transform.Rotate(0, 180, 0);
    }

    void Update()
    {
        transform.LookAt(cameraToLookAt.transform.position);
        transform.Rotate(0, 180, 0);
    }
}
