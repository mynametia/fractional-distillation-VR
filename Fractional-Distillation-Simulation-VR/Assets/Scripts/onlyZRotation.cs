using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onlyZRotation : MonoBehaviour
{
    protected void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.localEulerAngles.z));
    }
}
