using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowingTrayLiquidR : MonoBehaviour
{
    private float totalTime;
   
    // Start is called before the first frame update
    void Start()
    {
        totalTime = 1;
        StartCoroutine(LiquidRise(totalTime));
    }

    // Update is called once per frame
    private IEnumerator LiquidRise(float totalTime)
    {
        Vector3 objectScale;
        float period = totalTime / 20;
        float yDecrease = (period * 100) / totalTime;
        objectScale = transform.localScale;
        while (objectScale.y > -120)
        {
            objectScale.y -= yDecrease;
            transform.localScale = objectScale;
            yield return new WaitForSeconds(period);
        }
    }
}
