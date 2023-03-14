using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class condenserText : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatTextFlow;
    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatTextPercent;

    private string flowRateStr;
    private string ratioStr;

    public float flowRate;
    public float liqCon;

    public TextMeshProUGUI tmproTextFlow;
    public TextMeshProUGUI tmproTextPercent;

    // Start is called before the first frame update
    void Start()
    {
        formatTextFlow = "Condenser Flow Rate:\n{0} Kmol/hr";
        flowRateStr = flowRate.ToString("F2");
        tmproTextFlow.text = string.Format(formatTextFlow, flowRateStr);

        formatTextPercent = "{0}%\nEthanol";
        ratioStr = (liqCon * 100).ToString("F2");
        tmproTextPercent.text = string.Format(formatTextPercent, ratioStr);
    }
}
