using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbling : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float bubbleDelay = 0.1f, radius = 150f, height = 6f;
    public bool startBubble = true;
    public float SCALE = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 objectPos;
        objectPos = transform.localPosition;
        SCALE = spawn_column.SCALE;
        radius *= SCALE;
        height *= SCALE;
        StartCoroutine(Bubbling(objectPos.y));
    }

    private IEnumerator Bubbling(float trayHeight)
    {
        while (startBubble)
        {
            GameObject bubbleInstance = (GameObject)Instantiate(bubblePrefab, transform);
            bubbleInstance.transform.localPosition = new Vector3(Random.Range(-radius, radius), trayHeight + height, Random.Range(-radius, radius));

            yield return new WaitForSeconds(bubbleDelay);
        }
    }
}
