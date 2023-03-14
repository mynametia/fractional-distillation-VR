using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condenser_animation2 : MonoBehaviour
{
    public GameObject condenserLiquid2Prefab, condenserLiquid3Prefab;
    public float SCALE = 1f;
    public float liqCon;
    private GameObject[] vapourset1 = new GameObject[3];
    private GameObject[] chamberVapourSet = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        SCALE = spawn_column.SCALE;

        StartCoroutine(startCondenserAnimation());
    }

    
    private IEnumerator startCondenserAnimation()
    {
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

}
