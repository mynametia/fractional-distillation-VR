using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condenser_animation : MonoBehaviour
{
    public GameObject vapourPrefab, liquidDropletPrefab, collectorLiquidPrefab, waterSurfacePrefab, 
        condenserLiquid1Prefab, condenserLiquid2Prefab, condenserLiquid3Prefab,
        condenserVapour1aPrefab, condenserVapour1bPrefab, condenserVapour1cPrefab,
        condenserChamberVapour1Prefab, condenserChamberVapour2Prefab, condenserChamberVapour3Prefab;
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
        //StartCoroutine(vapourSpawnPoints(3));
        StartCoroutine(vapourMoleculeTubeAnimation(chamberVapourSet, 0.4f, 10));
        yield return new WaitForSeconds(4.2f);

        //spawn liquid molecules to collector
        StartCoroutine(liquidMoleculeTubeAnimation(condenserLiquid1Prefab, 0.3f, 13));
        yield return new WaitForSeconds(4.5f);

        StartCoroutine(collectorLiquidRise());
        yield return new WaitForSeconds(1f);

        StartCoroutine(liquidMoleculeTubeAnimation(condenserLiquid2Prefab, 0.3f, 12));
        yield return new WaitForSeconds(2.1f);

        StartCoroutine(liquidMoleculeTubeAnimation(condenserLiquid3Prefab, 0.2f, 24));
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

    //spawn vapour from column to condenser
    private IEnumerator preCondenserAnimation()
    {
        while (true)
        {
            GameObject vapourInstance = (GameObject)Instantiate(vapourPrefab, transform.parent.transform);
            vapourInstance.transform.localPosition = transform.localPosition + new Vector3(Random.Range(-8, 8),
                160, Random.Range(-8, 8)) * SCALE;
            vapourInstance.GetComponent<setColour>().liqCon = randomConcentrationGenerator(liqCon);
            yield return new WaitForSeconds(0.5f);
        }
    }

    //vapour spawn points
    private IEnumerator vapourSpawnPoints(int vapourSources)
    {
        int i;
        for (i = 0; i < vapourSources; i++)
        {
            StartCoroutine(condenserChamberAnimation());
            yield return null;
        }
    }

    //spawn vapour in condenser chamber
    private IEnumerator condenserChamberAnimation() 
    {
        int vapourCount = 0;
        while (vapourCount <= 50)
        {
            GameObject vapourInstance = (GameObject)Instantiate(vapourPrefab, transform.parent.transform);
            vapourInstance.transform.localPosition = transform.localPosition + new Vector3(230, 628 + Random.
                Range(-8, 8), Random.Range(-8, 8)) * SCALE;
            vapourInstance.GetComponent<setColour>().liqCon = randomConcentrationGenerator(liqCon);
            vapourCount++;
            yield return new WaitForSeconds(0.4f);
        }
    }

    //spawn liquid after condenser
    private IEnumerator preCollectorAnimation() 
    {
        while (true)
        {
            GameObject condenserLiquid = (GameObject)Instantiate(liquidDropletPrefab, transform.parent.transform);
            condenserLiquid.transform.localPosition = transform.localPosition + new Vector3(600, 628, 0) * SCALE;
            condenserLiquid.GetComponent<liquid_molecule_movement>().condenserYlocation = transform.localPosition.y;
            condenserLiquid.GetComponent<setColour>().liqCon = liqCon;
            yield return new WaitForSeconds(0.3f);
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

    //spawn liquid flowing down
    private IEnumerator postCollectorLiquidDown()
    {
        while (true)
        {
            GameObject condenserLiquid = (GameObject)Instantiate(liquidDropletPrefab, transform.parent.transform);
            condenserLiquid.transform.localPosition = transform.localPosition + new Vector3(757, 122, 0) * SCALE;
            condenserLiquid.GetComponent<liquid_molecule_movement>().condenserYlocation = transform.localPosition.y;
            condenserLiquid.GetComponent<setColour>().liqCon = liqCon;
            yield return new WaitForSeconds(0.3f);
        }
    }

    //spawn liquid flowing down
    private IEnumerator postCollectorLiquidBackToColumn()
    {
        while (true)
        {
            GameObject condenserLiquid = (GameObject)Instantiate(liquidDropletPrefab, transform.parent.transform);
            condenserLiquid.transform.localPosition = transform.localPosition + new Vector3(745, 50, 0) * SCALE;
            condenserLiquid.GetComponent<liquid_molecule_movement>().condenserYlocation = transform.localPosition.y;
            condenserLiquid.GetComponent<setColour>().liqCon = liqCon;
            yield return new WaitForSeconds(0.3f);
        }
    }

    //colour randomizer
    private float randomConcentrationGenerator(float ogCon)
    {
        return Random.Range(ogCon - 0.1f, ogCon + 0.1f);
    }
}
