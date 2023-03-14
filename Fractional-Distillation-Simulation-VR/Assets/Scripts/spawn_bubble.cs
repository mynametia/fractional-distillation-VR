using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_bubble : MonoBehaviour
{
    public GameObject bubblingAnimationPrefab;
    public float spawnPeriod = 3f;
    private int trayNumber, feedPosition;

    void Start()
    {
        StartCoroutine(SpawnBubbling());
    }

    private IEnumerator SpawnBubbling()
    {
        GameObject bubblingInstance = (GameObject)Instantiate(bubblingAnimationPrefab, transform);
        bubblingInstance.transform.localPosition = new Vector3(0,0,0);
        yield return new WaitForSeconds(spawnPeriod);
    }
}
