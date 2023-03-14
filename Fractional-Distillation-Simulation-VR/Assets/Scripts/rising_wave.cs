using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rising_wave : MonoBehaviour
{
    // Start is called before the first frame update
    public float yIncrease = 1f, maxIncrease = 15f;
    private float totalTime;
    public float SCALE = 1f;
    //GameObject mc;
    // Start is called before the first frame update
    void Start()
    {
        SCALE = spawn_column.SCALE;
        yIncrease *= SCALE;
        maxIncrease *= SCALE;
        totalTime = 1;
        StartCoroutine(LiquidRise(totalTime));
    }

    private IEnumerator LiquidRise(float totalTime)
    {
        Vector3 objectPos;
        float period = totalTime / (maxIncrease / yIncrease);
        float totalIncrease = 0;
        objectPos = transform.localPosition;
        while (totalIncrease < maxIncrease)
        {
            //Debug.Log("yScaling: " + objectScale.y);
            //Debug.Log("yIncrease: " + yIncrease);
            objectPos.y += yIncrease;
            transform.localPosition = objectPos;
            totalIncrease += yIncrease;
            yield return new WaitForSeconds(period);
        }
    }
}