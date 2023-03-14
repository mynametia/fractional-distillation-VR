using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reboiler_animation : MonoBehaviour
{
    public GameObject liquidDropletPrefab, vapourPrefab, columnVapourPrefab, reboilerLiquid1Prefab, 
        reboilerVapour1aPrefab, reboilerVapour1bPrefab, reboilerVapour1cPrefab,
        reboilerVapour2aPrefab, reboilerVapour2bPrefab, reboilerVapour2cPrefab,
        reboilerChamberVapour1Prefab, reboilerChamberVapour2Prefab, reboilerChamberVapour3Prefab,
        boilingSound;
    public int trayNumber;
    public float liqCon;
    public float SCALE = 1f;
    private GameObject[] vapourset1 = new GameObject[3];
    private GameObject[] vapourset2 = new GameObject[3];
    private GameObject[] chamberVapourSet = new GameObject[3];
    void Start()
    {
        SCALE = spawn_column.SCALE;

        vapourset1[0] = reboilerVapour1aPrefab;
        vapourset1[1] = reboilerVapour1bPrefab;
        vapourset1[2] = reboilerVapour1cPrefab;

        vapourset2[0] = reboilerVapour2aPrefab;
        vapourset2[1] = reboilerVapour2bPrefab;
        vapourset2[2] = reboilerVapour2cPrefab;

        chamberVapourSet[0] = reboilerChamberVapour1Prefab;
        chamberVapourSet[1] = reboilerChamberVapour2Prefab;
        chamberVapourSet[2] = reboilerChamberVapour3Prefab;

        StartCoroutine(startReboilerAnimation());
    }

    private IEnumerator startReboilerAnimation()
    {
        StartCoroutine(liquidMoleculeTubeAnimation(reboilerLiquid1Prefab, 0.3f, 16));
        yield return new WaitForSeconds(5f);

        //Spawn reboiler chamber vapour
        StartCoroutine(vapourMoleculeTubeAnimation(chamberVapourSet, 0.4f, 10));
        GameObject boiling = (GameObject)Instantiate(boilingSound, transform);
        boiling.transform.localPosition = new Vector3(0.5f, 0.2f, 0);
        yield return new WaitForSeconds(3.9f);

        StartCoroutine(vapourMoleculeTubeAnimation(vapourset1, 0.3f, 1));
        yield return new WaitForSeconds(1.2f);

        StartCoroutine(vapourMoleculeTubeAnimation(vapourset2, 0.3f, 5));
        yield return new WaitForSeconds(5f);

        StartCoroutine(vapourSpawnPoints(false, 60));
        
    }

    //spawn liquid molecules in tube
    private IEnumerator liquidMoleculeTubeAnimation(GameObject liqMoleculePrefab, float period, int maxCount)
    {
        int count = 0;
        while (count <= maxCount) {
            GameObject liquidMoleculeInstance = (GameObject)Instantiate(liqMoleculePrefab, transform);
            liquidMoleculeInstance.GetComponent<setColour>().liqCon = liqCon;
            count++;
            yield return new WaitForSeconds(period);
        }
    }

    //spawn a set of vapour molecules in tube
    private IEnumerator vapourMoleculeTubeAnimation(GameObject[] vapMolecules, float period, int maxCount)
    {
        int count = 0;
        while (count <= maxCount)
        {
            for (int i = 0; i < vapMolecules.Length; i++)
            {
                GameObject vapourMoleculeInstance = (GameObject)Instantiate(vapMolecules[i], transform);
                vapourMoleculeInstance.GetComponent<setColour>().liqCon = randomConcentrationGenerator(liqCon);
                yield return new WaitForSeconds(period);
            }
            count++;
        }
    }

    //liquid flowing to reboiler animation
    private IEnumerator reboilerLiquidFlow()
    {
        while (true)
        {
            GameObject reboilerLiquid = (GameObject)Instantiate(liquidDropletPrefab, transform.parent.transform);
            reboilerLiquid.transform.localPosition = transform.localPosition + new Vector3(0, -60 * SCALE, 0);
            reboilerLiquid.GetComponent<setColour>().liqCon = liqCon;
            yield return new WaitForSeconds(0.2f);
        }
    }

    //spawning multiple vapour spawn points
    private IEnumerator vapourSpawnPoints(bool reboiler, int vapourSources)
    {
        int i;
        if (reboiler == true)
        {
            for (i = 0; i < vapourSources; i++)
            {
                StartCoroutine(spawnVapourInReboilerChamber());
                yield return null;
            }
        }
        else 
        {
            for (i = 0; i < vapourSources; i++)
            {
                StartCoroutine(spawnVapourInColumn());
                yield return null;
            }
        }
    }

    //spawn column vapour
    private IEnumerator spawnVapourInColumn()
    {
        float period = 3f;
        float initialYpos = transform.localPosition.y - (7 * SCALE);
        float radius = 220 * SCALE;
        while (true)
        {
            float randRad = Random.Range(SCALE, radius);
            float randDeg = Random.Range(0, 359) * Mathf.Deg2Rad;

            yield return new WaitForSeconds(period + Random.Range(-10, 10) * 0.2f);
            GameObject vapourInstance = (GameObject)Instantiate(columnVapourPrefab, transform.parent.transform);
            vapourInstance.transform.localPosition = new Vector3(randRad * Mathf.Cos(randDeg), initialYpos, randRad * Mathf.Sin(randDeg));
            vapourInstance.GetComponent<vapourMovement>().trayNumber = trayNumber;
            vapourInstance.GetComponent<setColour>().liqCon = Random.Range(0.2f, 0.7f);

        }
    }

    //spawn reboiler chamber vapour
    private IEnumerator spawnVapourInReboilerChamber()
    {
        int vapourCount = 0;
        while (vapourCount <= 50)
        {
            GameObject vapourInstance = (GameObject)Instantiate(vapourPrefab, transform.parent.transform);
            vapourInstance.transform.localPosition = new Vector3(330, 152 + Random.
                Range(-8, 8), Random.Range(-8, 8)) * SCALE;
            vapourInstance.GetComponent<setColour>().liqCon = randomConcentrationGenerator(liqCon);
            vapourCount++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    //spawn reboiler tube vapour left
    private IEnumerator spawnVapourInReboilerTubeLeft()
    {
        while (true)
        {
            GameObject vapourInstance = (GameObject)Instantiate(vapourPrefab, transform.parent.transform);
            vapourInstance.transform.localPosition = new Vector3(688, 152 + Random.
                Range(-8, 8), Random.Range(-8, 8)) * SCALE;
            vapourInstance.GetComponent<setColour>().liqCon = randomConcentrationGenerator(liqCon);
            yield return new WaitForSeconds(0.5f);
        }
    }

    //spawn reboiler tube vapour up
    private IEnumerator spawnVapourInReboilerTubeUp()
    {
        while (true)
        {
            GameObject vapourInstance = (GameObject)Instantiate(vapourPrefab, transform.parent.transform);
            vapourInstance.transform.localPosition = new Vector3(768 + Random.
                Range(-8, 8), 172, Random.Range(-8, 8)) * SCALE;
            vapourInstance.GetComponent<setColour>().liqCon = randomConcentrationGenerator(liqCon);
            yield return new WaitForSeconds(0.4f + 0.1f*Random.Range(-1, 1));
        }
    }

    //colour randomizer
    private float randomConcentrationGenerator(float ogCon) 
    {
        return Random.Range(ogCon - 0.1f, ogCon + 0.1f);
    }
}
