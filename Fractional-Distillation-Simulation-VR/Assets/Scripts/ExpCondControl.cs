using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ExpCondControl : MonoBehaviour
{
    public TextMeshProUGUI trayNumberText;
    public TextMeshProUGUI feedPositionText;
    public TextMeshProUGUI feedRateText;
    public TextMeshProUGUI boilUpRatioText;
    public TextMeshProUGUI refluxRatioText;

    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatText = "{0}";
    // Start is called before the first frame update
    void Start()
    {
        trayNumberText.text = string.Format(formatText, SliderOptionsMenu.trayNumberValue);
        feedPositionText.text = string.Format(formatText, SliderOptionsMenu.feedPositionValue);
        feedRateText.text = string.Format(formatText, SliderOptionsMenu.feedRateValue);
        boilUpRatioText.text = string.Format(formatText, SliderOptionsMenu.boilUpRatioValue);
        refluxRatioText.text = string.Format(formatText, SliderOptionsMenu.refluxRatioValue);
    }
    public void returnToOptionsMenu()
    {
        SceneManager.LoadScene("VRSliderMenuScene");
    }

}
