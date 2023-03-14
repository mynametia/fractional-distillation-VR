using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rising_liquid : MonoBehaviour
{
    public float yIncrease = 1f;
    private float totalTime;
    //GameObject mc;
    // Start is called before the first frame update
    void Start()
    {
        //mc = GameObject.FindWithTag("MainCamera");
        totalTime = 1;
        StartCoroutine(LiquidRise(totalTime));
    }

    private IEnumerator LiquidRise(float totalTime) 
    {
        Vector3 objectScale;
        float period = totalTime/(20/yIncrease);
        objectScale = transform.localScale;
        while (objectScale.y < 20) {
            //Debug.Log("yScaling: " + objectScale.y);
            //Debug.Log("yIncrease: " + yIncrease);
            objectScale.y += yIncrease;
            transform.localScale = objectScale;
            yield return new WaitForSeconds(period);
        }
    }
}
