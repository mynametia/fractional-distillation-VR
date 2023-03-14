using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vapourMovement : MonoBehaviour
{
    public int trayNumber;

    private float startY, startX, forceScaler;

    private Renderer rend;

    public float SCALE = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SCALE = spawn_column.SCALE;
        forceScaler = transform.parent.transform.localScale.x*SCALE*2f;

        startY = transform.localPosition.y;
        startX = transform.localPosition.x;

        if (gameObject.tag == "column") //column vapour
        {
            StartCoroutine(columnVapourAnimation(startY + (240 + (trayNumber - 1) * 120) * SCALE, startY));
        }
        else if (startY < 360 * SCALE)
        {
            if (startX <= 660 * SCALE) //reboiler chamber vapour
            {
                //StartCoroutine(chamberVapourAnimation(670 * SCALE, 285 * SCALE));
            }
            else if (startX < 760 * SCALE) //reboiler tube left vapour
            {
                StartCoroutine(reboilerTubeLeft(874 * SCALE, 688 * SCALE));
            }
            else //reboiler tube up vapour
            {
                StartCoroutine(reboilerTubeUp(260 * SCALE));
            }
        }
        else
        {
            if (startX >= 200 * SCALE)
            {
                //StartCoroutine(chamberVapourAnimation(590 * SCALE, 205 * SCALE));
            }
            else
            {
                StartCoroutine(condenserTubeUp(210 * SCALE));
            }
        }
    }

    //animation for column vapour
    private IEnumerator columnVapourAnimation(float maxY, float minY)
    {
        while (true) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, forceScaler*(5 + Random.Range(0, 2)), 0));
            if (transform.localPosition.y >= maxY || transform.localPosition.y < minY) { Destroy(gameObject); }
            yield return null;
        }
    }

    //animation for reboiler/condenser chamber vapour
    private IEnumerator chamberVapourAnimation(float maxX, float minX)
    {
        GetComponent<SphereCollider>().material.bounciness = 1;
        while (true) 
        {
            GetComponent<Rigidbody>().AddForce(forceScaler * (new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3))));
            if (transform.localPosition.x > maxX || transform.localPosition.x < minX) { Destroy(gameObject); }
            yield return null;
        }
    }

    /*animation for condenser chamber vapour
    private IEnumerator condenserChamberVapourAnimation()
    {
        GetComponent<SphereCollider>().material.bounciness = 1;
        while (true)
        {
            GetComponent<Rigidbody>().AddForce(forceScaler * (new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3))));
            if (transform.localPosition.x > 590 * SCALE || transform.localPosition.x < 205 * SCALE) { Destroy(gameObject); }
            yield return null;
        }
    } */

    //animation for reboiler tube to left
    private IEnumerator reboilerTubeLeft(float maxX, float minX)
    {
        while (true) 
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(forceScaler * (15 + Random.Range(1, 2)), 0, 0));
            if (transform.localPosition.x < minX || transform.localPosition.x > maxX) { Destroy(gameObject); }
            yield return null;
        }
    }

    //animation for reboiler tube up
    private IEnumerator reboilerTubeUp(float minX)
    {
        while (true)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, forceScaler * (15 + Random.Range(1, 2)), 0));
            if (transform.localPosition.x < minX) { Destroy(gameObject); }
            yield return null;
        }
    }

    //animation for condenser tube up
    private IEnumerator condenserTubeUp(float maxX)
    {
        while (true)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, forceScaler * (15 + Random.Range(1, 2)), 0));
            if (transform.localPosition.x > maxX) { Destroy(gameObject); }
            yield return null;
        }
    }
}
