
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liquid_molecule_movement : MonoBehaviour
{
    private float startY, startX, forceScaler;
    public float condenserYlocation;
    public float SCALE = 1f;
    //public GameObject objSpawnerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SCALE = spawn_column.SCALE;
        forceScaler = transform.parent.transform.localScale.x * SCALE;
        startY = transform.localPosition.y;
        startX = transform.localPosition.x;

        //if (startX < -240 * SCALE)
        if (startX < -0.24f)
        {
            //feed liquid flow
            //StartCoroutine(leftBoundary(startY, -240 * SCALE));
            StartCoroutine(leftBoundary(startY, -0.24f));
        }
        //else if (startY < 367 * SCALE)
        else if (startY < 0.367f)
        {
            //reboiler liquid flow
            //StartCoroutine(leftBoundary(startY, 280 * SCALE));
            StartCoroutine(leftBoundary(startY, 0.28f));
        }
        else //condenser liquid flow
        {
            //if (startY > condenserYlocation + 500 * SCALE)
            if (startY > condenserYlocation + 0.5f)
            {
                //pre collector liquid flow
                //StartCoroutine(lowerBoundary(600 * SCALE, condenserYlocation + 480 * SCALE));
                StartCoroutine(lowerBoundary(600 * SCALE, condenserYlocation + 0.48f));
            }
            //else if (startY > condenserYlocation + 100 * SCALE)
            else if (startY > condenserYlocation + 0.1f)
            {
                //post collector downward liquid flow
                //StartCoroutine(leftBoundary(startY, 835 * SCALE));
                StartCoroutine(leftBoundary(startY, 0.835f));
            }
            else 
            {
                //post collector back to column flow
                //StartCoroutine(rightBoundary(startX, 270 * SCALE));
                StartCoroutine(rightBoundary(startX, 0.27f));
            }
        }
    }
    
    //liquid falling down, exit left
    private IEnumerator leftBoundary(float startY, float endX) 
    {
        while (true)
        {
            if (transform.localPosition.x > endX || transform.localPosition.y > startY)
            { 
                Destroy(gameObject); 
            }
            else { 
                GetComponent<Rigidbody>().AddForce(new Vector3(0, -20 * forceScaler, 0)); 
            }
            yield return null; 
        }
    }

    //liquid going right, exit right
    private IEnumerator rightBoundary(float startX, float endX)
    {
        while (true)
        {
            if (transform.position.x > startX || transform.position.x < endX)
            {
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0, 0));
            }
            yield return null;
        }
    }

    //liquid going left, exit down
    private IEnumerator lowerBoundary(float startX, float endY)
    {
        while (true)
        {
            if (transform.position.x < startX || transform.position.y < endY)
            {
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(20, 0, 0));
            }
            yield return null;
        }
    }

}
