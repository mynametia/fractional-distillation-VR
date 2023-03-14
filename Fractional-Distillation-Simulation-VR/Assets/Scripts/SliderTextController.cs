using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatText = "{0}";

    private TextMeshProUGUI tmproText;
    
    // Start is called before the first frame update
    private void Start()
    {
        tmproText = GetComponent<TextMeshProUGUI>();

        GetComponentInParent<Slider>().onValueChanged.AddListener(HandleValueChanged);
    }

    private void HandleValueChanged(float value)
    {
        tmproText.text = string.Format(formatText, value);
    }
}
