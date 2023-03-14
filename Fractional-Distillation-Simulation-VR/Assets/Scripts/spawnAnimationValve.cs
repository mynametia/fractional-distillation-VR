using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnAnimationValve : MonoBehaviour
{
    public GameObject feedLiquid1Prefab, feedLiquid2Prefab, waterSurfacePrefab, leftTrayLiquid, rightTrayLiquid, 
        reboilerLiquid1Prefab, reboilerLiquid2Prefab,
         condenserLiquid1Prefab, condenserLiquid2Prefab;

    public GameObject feedValve, reboilerValve, condenserValve;

    private Material columnMat, glowingMat;

    public float SCALE = 1f;
    public int trayNumber, feedPosition, fPos;
    //private float timeElapsed = 0;

    public bool validSolution = true;
    private bool reboilerAnimationOk = false, condenserAnimationOk = false,
        feedAnimationStarted = false, reboilerAnimationStarted = false, condenserAnimationStarted = false; 
    // Start is called before the first frame update
    void Start()
    {
        trayNumber = SliderOptionsMenu.trayNumberValue;
        feedPosition = SliderOptionsMenu.feedPositionValue;

        SCALE = spawn_column.SCALE;

        if (trayNumber < 6) { trayNumber = 6; }
        else if (trayNumber > 20) { trayNumber = 20; }

        if (feedPosition >= trayNumber) { feedPosition = trayNumber - 1; }
        else if (feedPosition < 1) { feedPosition = 1; }

        fPos = trayNumber - feedPosition;

        glowingMat = feedValve.GetComponent<Renderer>().material;
        columnMat = reboilerValve.GetComponent<Renderer>().material;

        if (validSolution)
        {
            GameObject feedLiquidInstance = (GameObject)Instantiate(feedLiquid1Prefab, transform);
            feedLiquidInstance.transform.localPosition = new Vector3(0, 467 + (fPos - 1) * 100 + fPos * 20, 0) * SCALE;
        }
        else 
        {
            feedValve.GetComponent<Renderer>().material = columnMat;
        }
    }
 
    public void startFeedAnimationFxn()
    {
        if (validSolution)
        {
            StartCoroutine(startFeedAnimation());
        }
    }

    public void startReboilerAnimationFxn()
    {
        if (validSolution)
        {
            StartCoroutine(startReboilerAnimation());
        }
    }

    public void startCondenserAnimationFxn()
    {
        if (validSolution)
        {
            StartCoroutine(startCondenserAnimation());
        }
    }

    public IEnumerator startFeedAnimation() 
    {
        if (!feedAnimationStarted) 
        {
            feedAnimationStarted = true;
            feedValve.GetComponent<Renderer>().material = columnMat;
            yield return new WaitForSeconds(0.01f);
            //spawn feed liquid
            spawnFeedLiquid(fPos);
            yield return new WaitForSeconds(6.5f);

            //spawn tray liquid going down
            for (int i = fPos; i > 0; i--)
            {
                if (i % 2 == 1) { spawnTrayLiquidLeft(true, i, trayNumber); }
                else { spawnTrayLiquidLeft(false, i, trayNumber); }
                yield return new WaitForSeconds(1.2f);
            }

            spawnReboilerLiquid1();
            yield return new WaitForSeconds(1.2f);
            //Debug.Log("Valve 2 ready to open! Time elapsed: " + timeElapsed);
            reboilerAnimationOk = true;
            reboilerValve.GetComponent<Renderer>().material = glowingMat;
        }
    }

    public IEnumerator startReboilerAnimation()
    {
        if (reboilerAnimationOk && !reboilerAnimationStarted)
        {
            reboilerAnimationStarted = true;
            reboilerValve.GetComponent<Renderer>().material = columnMat;
            //spawn last level and reboiler liquid
            spawnReboilerLiquid2(trayNumber);
            yield return new WaitForSeconds(24.2f + (trayNumber - 6) * 0.5f);
            //timeElapsed += 25.4f + (trayNumber - 6) * 0.5f;
            //Debug.Log("Valve 2 ready to open! Time elapsed: " + timeElapsed);
            spawnCondenserLiquid1(trayNumber);
            yield return new WaitForSeconds(14.7f);
            condenserAnimationOk = true;
            condenserValve.GetComponent<Renderer>().material = glowingMat;
        }
    }

    public IEnumerator startCondenserAnimation()
    {
        if (condenserAnimationOk && !condenserAnimationStarted)
        {
            condenserAnimationStarted = true;
            //condenserValve.GetComponent<Renderer>().material.SetVector("Color_7FFD90AF", valveOriginalColour);
            condenserValve.GetComponent<Renderer>().material = columnMat;
            //spawn condenser liquid
            spawnCondenserLiquid2(trayNumber);
            yield return new WaitForSeconds(8.3f);

            //spawn rest of tray liquid going down
            for (int i = trayNumber; i > fPos; i--)
            {
                if (i % 2 == 1) { spawnTrayLiquidLeft(true, i, trayNumber); }
                else { spawnTrayLiquidLeft(false, i, trayNumber); }
                yield return new WaitForSeconds(1.2f);
            }
        }
    }
    
    //spawn feed liquid prefab
    private void spawnFeedLiquid(int fPos)
    {
        GameObject feedLiquidInstance = (GameObject)Instantiate(feedLiquid2Prefab, transform);
        feedLiquidInstance.transform.localPosition = new Vector3(0, 467 + (fPos - 1) * 100 + fPos * 20, 0) * SCALE;
        feedLiquidInstance.GetComponent<feedFlowRate>().feedRate = GetComponent<calculatorsAttempt2>().feedR;
    }

    //spawn tray liquid prefab
    private void spawnTrayLiquidLeft(bool isLeft, int trayLevel, int trayNumber)
    {
        //trayLevel counts from the bottom
        if (isLeft)
        {
            GameObject liquidColumnInstance = (GameObject)Instantiate(leftTrayLiquid, transform);
            liquidColumnInstance.transform.localPosition = new Vector3(0, (367 + trayLevel * 120) * SCALE, 0);
            liquidColumnInstance.GetComponent<ethanolConDisplay>().endCon =
                GetComponent<calculatorsAttempt2>().XvariableList[trayNumber - trayLevel];
        }
        else
        {
            GameObject liquidColumnInstance = (GameObject)Instantiate(rightTrayLiquid, transform);
            liquidColumnInstance.transform.localPosition = new Vector3(0, (367 + trayLevel * 120) * SCALE, 0);
            liquidColumnInstance.GetComponent<ethanolConDisplay>().endCon =
                GetComponent<calculatorsAttempt2>().XvariableList[trayNumber - trayLevel];
        }
    }

    private void spawnReboilerLiquid1()
    {
        GameObject reboilerLiquidInstance = (GameObject)Instantiate(reboilerLiquid1Prefab, transform);
        reboilerLiquidInstance.transform.localPosition = new Vector3(0, 367 * SCALE, 0);
        reboilerLiquidInstance.GetComponent<reboilerConcentration>().liqCon = GetComponent<calculatorsAttempt2>().successXb;
    }

    private void spawnReboilerLiquid2(int trayNumber)
    {
        GameObject reboilerLiquidInstance = (GameObject)Instantiate(reboilerLiquid2Prefab, transform);
        reboilerLiquidInstance.transform.localPosition = new Vector3(0, 367 * SCALE, 0);
        reboilerLiquidInstance.GetComponent<reboiler_animation>().trayNumber = trayNumber;
        reboilerLiquidInstance.GetComponent<reboiler_animation>().liqCon = GetComponent<calculatorsAttempt2>().successXb;
        reboilerLiquidInstance.GetComponent<reboilerText>().flowRate = GetComponent<calculatorsAttempt2>().Fb;
        reboilerLiquidInstance.GetComponent<reboilerText>().liqCon = GetComponent<calculatorsAttempt2>().successXb;
    }

    private void spawnCondenserLiquid1(int trayNumber)
    {
        GameObject condenserLiquidInstance = (GameObject)Instantiate(condenserLiquid1Prefab, transform);
        condenserLiquidInstance.transform.localPosition = new Vector3(0, (487 + (trayNumber - 1) * 120) * SCALE, 0);
        condenserLiquidInstance.GetComponent<condenser_animation1>().liqCon = GetComponent<calculatorsAttempt2>().successXd;
    }

    private void spawnCondenserLiquid2(int trayNumber)
    {
        GameObject condenserLiquidInstance = (GameObject)Instantiate(condenserLiquid2Prefab, transform);
        condenserLiquidInstance.transform.localPosition = new Vector3(0, (487 + (trayNumber - 1) * 120) * SCALE, 0);
        condenserLiquidInstance.GetComponent<condenserText>().flowRate = GetComponent<calculatorsAttempt2>().Fd;
        condenserLiquidInstance.GetComponent<condenserText>().liqCon = GetComponent<calculatorsAttempt2>().successXd;
        condenserLiquidInstance.GetComponent<condenser_animation2>().liqCon = GetComponent<calculatorsAttempt2>().successXd;
    }


}
