using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class reboilerConcentration : MonoBehaviour
{
    public float liqCon;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<colourChange>().liqCon = liqCon;
        GetComponentInChildren<colourChangeSimple>().liqCon = liqCon;
        transform.Find("waterColumnSurfacePrefab").GetComponent<colourChangeSimple>().liqCon = liqCon;
    }

    
   
}
