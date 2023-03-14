using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedAnimation : MonoBehaviour
{
    public GameObject liquidDropletPrefab;
    public float SCALE = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //spawn liquid droplet
        //SCALE = spawn_column.SCALE;
        StartCoroutine(FeedLiquidFlow());
    }

    private IEnumerator FeedLiquidFlow()
    {
        Vector3 feedLocalPos = new Vector3(-0.2f, -0.01f, 0.18f);
        //Vector3 feedLocalPos = new Vector3(-200f, -10, 180f) * SCALE;
        while (true)
        {
            //feed column is 375 wide
            GameObject feedLiquid = (GameObject)Instantiate(liquidDropletPrefab, transform.parent.transform);
            feedLiquid.transform.localPosition = transform.localPosition + feedLocalPos;
            feedLiquid.GetComponent<setColour>().liqCon = 0.5f;
            yield return new WaitForSeconds(0.15f);
        }

    }

}
