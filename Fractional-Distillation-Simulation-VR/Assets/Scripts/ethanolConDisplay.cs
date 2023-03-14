using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ethanolConDisplay : MonoBehaviour
{
    public float endCon = 50f;

    private string endConStr;

    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatText;

    public TextMeshProUGUI tmproText;
    // Start is called before the first frame update
    void Start()
    {
        formatText = "{0}%\nEthanol";
        endConStr = (endCon * 100).ToString("F2");
        tmproText.text = string.Format(formatText, endConStr);

        GetComponentInChildren<colourChange>().liqCon = endCon;
        transform.Find("waterColumnSurfacePrefab").GetComponent<colourChangeSimple>().liqCon = endCon;
        //Debug.Log("obj name:" + gameObject.name);
        if (gameObject.tag == "left")
        {
            //Debug.Log("trayLiquidFlowLeft liqCon assigned");
            transform.Find("trayLiquidFlowLeft").GetComponent<colourChangeSimple>().liqCon = endCon;
        }
        else if (gameObject.tag == "right")
        {
            //Debug.Log("trayLiquidFlowRight liqCon assigned");
            transform.Find("trayLiquidFlowRight").GetComponent<colourChangeSimple>().liqCon = endCon;
        }
        
    }

    
}
