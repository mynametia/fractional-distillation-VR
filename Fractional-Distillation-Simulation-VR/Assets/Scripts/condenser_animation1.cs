using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condenser_animation1 : MonoBehaviour
{
    public GameObject collectorLiquidPrefab, waterSurfacePrefab, condenserLiquid1Prefab,
        condenserVapour1aPrefab, condenserVapour1bPrefab, condenserVapour1cPrefab,
        condenserChamberVapour1Prefab, condenserChamberVapour2Prefab, condenserChamberVapour3Prefab,
        condenseSound, waterSound;
    public float SCALE = 1f;
    public float liqCon;
    private GameObject[] vapourset1 = new GameObject[3];
    private GameObject[] chamberVapourSet = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        SCALE = spawn_column.SCALE;

        vapourset1[0] = condenserVapour1aPrefab;
        vapourset1[1] = condenserVapour1bPrefab;
        vapourset1[2] = condenserVapour1cPrefab;

        chamberVapourSet[0] = condenserChamberVapour1Prefab;
        chamberVapourSet[1] = condenserChamberVapour2Prefab;
        chamberVapourSet[2] = condenserChamberVapour3Prefab;

        StartCoroutine(startCondenserAnimation());
    }

    
    private IEnumerator startCondenserAnimation()
    {
        //spawn vapour in tube travelling to condenser
        StartCoroutine(vapourMoleculeTubeAnimation(vapourset1, 0.3f, 7));
        yield return new WaitForSeconds(5f);

        //spawn vapour in condenser chamber
        StartCoroutine(vapourMoleculeTubeAnimation(chamberVapourSet, 0.4f, 10));
        GameObject condensation = (GameObject)Instantiate(condenseSound, transform);
        condensation.transform.localPosition = new Vector3(0.39f, 0.5f, 0);
        yield return new WaitForSeconds(4.2f);

        //spawn liquid molecules to collector
        StartCoroutine(liquidMoleculeTubeAnimation(condenserLiquid1Prefab, 0.3f, 13));
        GameObject flowingWater = (GameObject)Instantiate(waterSound, transform);
        flowingWater.transform.localPosition = new Vector3(0.7f, 0.5f, 0);
        yield return new WaitForSeconds(4.5f);

        StartCoroutine(collectorLiquidRise());
    }

    //spawn liquid molecules in tube
    private IEnumerator liquidMoleculeTubeAnimation(GameObject liqMoleculePrefab, float period, int maxCount)
    {
        int count = 0;
        while (count <= maxCount)
        {
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

    //spawn collector liquid
    private IEnumerator collectorLiquidRise()
    {
        GameObject collectorLiquidInstance = (GameObject)Instantiate(collectorLiquidPrefab, transform.parent.transform);
        collectorLiquidInstance.transform.localPosition = transform.localPosition + new Vector3(577, 130, -180) * SCALE;
        collectorLiquidInstance.GetComponent<colourChangeSimple>().liqCon = liqCon;

        GameObject collectorSurfaceInstance = (GameObject)Instantiate(waterSurfacePrefab, transform.parent.transform);
        collectorSurfaceInstance.transform.localPosition = transform.localPosition + new Vector3(577+180, 130+28, 0) * SCALE;
        collectorSurfaceInstance.GetComponent<colourChange>().liqCon = liqCon;
        
        //og scale is 0.1 in y direction
        float totalTime = 1.80f;
        Vector3 scaleChange = new Vector3(0, (1 - collectorLiquidInstance.transform.localScale.y) / 90, 0);
        //float yIncrease = (1-objectScale.y)/90;
        float period = totalTime / 90;
        Vector3 posChange = new Vector3(0, 2.8f * SCALE, 0);
        while (totalTime > 0)
        {
            //objectScale.y += yIncrease;
            collectorLiquidInstance.transform.localScale += scaleChange;
            collectorSurfaceInstance.transform.localPosition += posChange;
            totalTime -= period;
            yield return new WaitForSeconds(period);
        }
    }

    //colour randomizer
    private float randomConcentrationGenerator(float ogCon)
    {
        return Random.Range(ogCon - 0.1f, ogCon + 0.1f);
    }
}
