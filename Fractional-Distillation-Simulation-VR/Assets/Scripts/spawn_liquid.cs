using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_liquid : MonoBehaviour
{
    public GameObject waterColumnPrefab, waterSurfacePrefab, feedLiquidPrefab, collectorLiquidPrefab, liquidDropletPrefab, reboilerLiquidPrefab;
    public float period = 3f;
    private int trayNumber, feedPosition;
    void Start()
    {
        trayNumber = GetComponent<spawn_column>().trayNumber;
        feedPosition = trayNumber - GetComponent<spawn_column>().feedPosition;

        //spawn feed liquid
        GameObject feedLiquidInstance = (GameObject)Instantiate(feedLiquidPrefab);
        feedLiquidInstance.transform.position = new Vector3(-437, 695 + (feedPosition - 1) * 100 + (feedPosition) * 20, -180);
        GameObject liquidSurfaceInstanceFeed = (GameObject)Instantiate(waterSurfacePrefab);
        liquidSurfaceInstanceFeed.transform.position = new Vector3(-637, 1065 + (feedPosition - 1) * 100 + (feedPosition) * 20, 0);
        liquidSurfaceInstanceFeed.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        liquidSurfaceInstanceFeed.GetComponent<rising_wave>().enabled = false;
        liquidSurfaceInstanceFeed.GetComponent<colourChange>().enabled = false;

        //spawn collector liquid
        GameObject collectorLiquidInstance = (GameObject)Instantiate(collectorLiquidPrefab);
        collectorLiquidInstance.transform.position = new Vector3(578, 897 + (trayNumber - 1) * 120, -180);
        GameObject liquidSurfaceInstanceCollector = (GameObject)Instantiate(waterSurfacePrefab);
        liquidSurfaceInstanceCollector.transform.position = new Vector3(758, 892 + (trayNumber - 1) * 120, 0);
        liquidSurfaceInstanceCollector.transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        liquidSurfaceInstanceCollector.GetComponent<rising_wave>().enabled = false;
        liquidSurfaceInstanceCollector.GetComponent<colourChange>().enabled = false;

        //spawn liquid droplet
        //StartCoroutine(FeedLiquidFlow(feedPosition));

        //spawn tray liquid
        StartCoroutine(TrayLiquidFill(trayNumber, feedPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FeedLiquidFlow(int feedPosition)
    {
        while (true)
        {
            //-643 to -630 , middle is roughy -637
            GameObject feedLiquid = (GameObject)Instantiate(liquidDropletPrefab);
            //feedLiquid.transform.position = new Vector3(Random.Range(-643,-630), 695 + (feedPosition - 1) * 100 + (feedPosition) * 20, Random.Range(-6,6));
            feedLiquid.transform.position = new Vector3(-636.5f, 676 + (feedPosition - 1) * 100 + (feedPosition) * 20, 0);
            yield return new WaitForSeconds(0.1f);
        }

    }

    private IEnumerator reboilerLiquidFlow(int finalTrayYPos)
    {
        GameObject reboilerLiquidInstance = (GameObject)Instantiate(reboilerLiquidPrefab);
        reboilerLiquidInstance.transform.position = new Vector3(0, finalTrayYPos, 0);
        yield return null;
    }

    private IEnumerator TrayLiquidFill(int trayNumber, int feedPosition)
    {
        //note:spawn different thing at lowest position!   
        int i;

        //spawning tray liquids
        for (i = feedPosition; i >= feedPosition - trayNumber; i--) {
            if (i != 0)
            {
                GameObject liquidColumnInstance = (GameObject)Instantiate(waterColumnPrefab);
                GameObject liquidSurfaceInstance = (GameObject)Instantiate(waterSurfacePrefab);
                if (i <= feedPosition && i > 0)
                {
                    liquidColumnInstance.transform.position = new Vector3(0, 367 + i * 120, 0);
                    liquidSurfaceInstance.transform.position = new Vector3(0, 367 + i * 120, 0);

                    liquidColumnInstance.GetComponent<ethanolConDisplay>().endCon = GetComponent<calculatorsAttempt2>().XvariableList[trayNumber-i];
                }
                else
                {
                    liquidColumnInstance.transform.position = new Vector3(0, 367 + (trayNumber + i + 1) * 120, 0);
                    liquidSurfaceInstance.transform.position = new Vector3(0, 367 + (trayNumber + i + 1) * 120, 0);

                    liquidColumnInstance.GetComponent<ethanolConDisplay>().endCon = GetComponent<calculatorsAttempt2>().XvariableList[-i-1];
                }
            }
            //spawn different water col. at last segment
            else {
                StartCoroutine(reboilerLiquidFlow(367 + i * 120));
            }
            yield return new WaitForSeconds(period);
        }
        
    }

}
