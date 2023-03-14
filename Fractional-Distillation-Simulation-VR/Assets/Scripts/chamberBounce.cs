using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamberBounce : MonoBehaviour
{
    public Vector3 forceMagnitude = new Vector3(0,0,0);
    //public float minForce = 0.03f, maxForce = 0.07f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().material.bounciness = 1;
        float forceScaler = 0.055f;
        GetComponent<Rigidbody>().AddForce(forceScaler * forceMagnitude);
        //GetComponent<Rigidbody>().AddForce(forceScaler * new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3)));
        //StartCoroutine(chamberVapourAnimation(minForce, maxForce));
        /*
        float forceScaler = 0.01f;
        Vector3 force = forceScaler * new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3));
        GetComponent<Rigidbody>().AddForce(forceScaler * new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3)));
        */
    }

    //animation for reboiler/condenser chamber vapour
    private IEnumerator chamberVapourAnimation(float minMagnitude, float maxMagnitude)
    {
        GetComponent<SphereCollider>().material.bounciness = 1;
        float forceScaler = 0.05f;
        Vector3 force = forceScaler * new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3));
        GetComponent<Rigidbody>().AddForce(forceScaler * new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3)));
        while (true)
        {
            //GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(minMagnitude, maxMagnitude),
            //Random.Range(minMagnitude, maxMagnitude) * (-1 ^ Random.Range(1, 2)),
            //Random.Range(minMagnitude, maxMagnitude) * (-1 ^ Random.Range(1, 2))));
            //GetComponent<Rigidbody>().AddForce(force);
            //GetComponent<Rigidbody>().AddForce(forceScaler * new Vector3(15, 10 * Random.Range(-3, 3), 10 * Random.Range(-3, 3)));
            //if (transform.localPosition.x > maxX || transform.localPosition.x < minX) { Destroy(gameObject); }
            yield return null;
        }
    }
}
