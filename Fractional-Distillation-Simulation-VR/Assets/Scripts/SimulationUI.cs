using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SimulationUI : MonoBehaviour
{
    /*
    public Camera cam;

    public GameObject ExpCondCanvas;
    public GameObject ToggleButton;

    public TextMeshProUGUI toggleButtonText;
    public TextMeshProUGUI trayNumberText;
    public TextMeshProUGUI feedPositionText;
    public TextMeshProUGUI feedRateText;
    public TextMeshProUGUI boilUpRatioText;
    public TextMeshProUGUI refluxRatioText;

    private Vector3 ogPos;
    private Vector3 ogRot;
    private float ogScale;

    private bool condActive;

    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatText = "{0}";
    */
    // Start is called before the first frame update
    void Start()
    {
        /*
        ogPos = cam.transform.position;
        ogRot = cam.transform.eulerAngles;
        ogScale = cam.orthographicSize;

        trayNumberText.text = string.Format(formatText, SliderOptionsMenu.trayNumberValue);
        feedPositionText.text = string.Format(formatText, SliderOptionsMenu.feedPositionValue);
        feedRateText.text = string.Format(formatText, SliderOptionsMenu.feedRateValue);
        boilUpRatioText.text = string.Format(formatText, SliderOptionsMenu.boilUpRatioValue);
        refluxRatioText.text = string.Format(formatText, SliderOptionsMenu.refluxRatioValue);

        toggleButtonText.text = "Show Conditions";

        ExpCondCanvas.SetActive(false);
        condActive = false;
        */
    }

    public void returnToOptionsMenu()
    {
        SceneManager.LoadScene("VRSliderMenuScene");
    }

    /*
    public void resetViewPoint() 
    {
        cam.transform.position = ogPos;
        cam.transform.eulerAngles = ogRot;
        cam.orthographicSize = ogScale;
    }

    public void displayExpCond()
    {
        ExpCondCanvas.SetActive(!ExpCondCanvas.activeInHierarchy);
        if (condActive == false) {
            toggleButtonText.text = "Hide Conditions";
            //ToggleButton.transform.position += new Vector3(0,190f,0);
            condActive = true;
        }
        else {
            toggleButtonText.text = "Show Conditions";
            //ToggleButton.transform.position -= new Vector3(0, 190f, 0);
            condActive = false;
        }
        
    }
    */
}
