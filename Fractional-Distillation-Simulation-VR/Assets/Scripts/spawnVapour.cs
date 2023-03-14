using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnVapour : MonoBehaviour
{
    public GameObject vapourPrefab;

    public float period = 5f;
    public int vapourSources = 50;
    public int initialYpos = 360;
    public int trayNumber;

    public bool startVapour = true;

    private int radius = 220;
    private float v;

    Renderer rend;
    void Start()
    {
        StartCoroutine(vapourSpawnPoints());
    }

    private IEnumerator vapourSpawnPoints()
    {
        int i;
        for (i = 0; i < vapourSources; i++)
        {
            StartCoroutine(vapourSpawning());
            yield return null;
        }
    }

    private IEnumerator vapourSpawning()
    {
        while (startVapour)
        {
            int randRad = Random.Range(1, radius);
            float randDeg = Random.Range(0, 359) * Mathf.Deg2Rad;
            
            yield return new WaitForSeconds(period+Random.Range(-10,10)*0.2f);
            GameObject vapourInstance = (GameObject)Instantiate(vapourPrefab);
            vapourInstance.transform.position = new Vector3(randRad * Mathf.Cos(randDeg), initialYpos, randRad * Mathf.Sin(randDeg));
            vapourInstance.GetComponent<vapourMovement>().trayNumber = trayNumber;
            
        }
    }
}
