using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class feedFlowRate : MonoBehaviour
{
    
    public GameObject[] mainCameras;

    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatText;

    public float feedRate;

    private string flowRateStr;
    public TextMeshProUGUI tmproText;
    // Start is called before the first frame update
    void Start()
    {
        formatText = "Feed Flow Rate:\n{0} Kmol/hr";

        flowRateStr = feedRate.ToString("F2");
        tmproText.text = string.Format(formatText, flowRateStr);
    }

}
