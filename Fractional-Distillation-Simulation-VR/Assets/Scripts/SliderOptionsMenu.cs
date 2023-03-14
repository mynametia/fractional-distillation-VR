using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SliderOptionsMenu : MonoBehaviour
{

    public Slider trayNumberSlider;
    public Slider feedPositionSlider;
    public Slider feedRateSlider;
    public Slider boilUpRatioSlider;
    public Slider refluxRatioSlider;

    public TextMeshProUGUI trayNumberText;
    public TextMeshProUGUI feedPositionText;
    public TextMeshProUGUI feedRateText;
    public TextMeshProUGUI boilUpRatioText;
    public TextMeshProUGUI refluxRatioText;

    public static int trayNumberValue = 6;
    public static int feedPositionValue = 1;
    public static int feedRateValue = 50;
    public static float boilUpRatioValue = 2.5f;
    public static float refluxRatioValue = 0.1f;

    [SerializeField]
    [Tooltip("The text shown will be formatted using this string. {0} is replaced with the actual value")]
    private string formatText = "{0}";
    void Start()
    {
        trayNumberValue = (int)trayNumberSlider.value;
        feedPositionSlider.maxValue = trayNumberSlider.value - 1;
        feedPositionValue = (int)feedPositionSlider.value;
        feedRateValue = (int)feedRateSlider.value * 25;
        boilUpRatioValue = 2.50f * (int)boilUpRatioSlider.value;
        refluxRatioValue = 2.50f * (int)refluxRatioSlider.value;
    }

    public void TrayNumberChanged()
    {
        trayNumberText.text = string.Format(formatText, trayNumberSlider.value);
        trayNumberValue = (int)trayNumberSlider.value;
        feedPositionSlider.maxValue = trayNumberSlider.value - 1;
    }
    public void FeedPositionChanged()
    {
        feedPositionText.text = string.Format(formatText, feedPositionSlider.value);
        feedPositionValue = (int)feedPositionSlider.value;
    }
    public void FeedRateChanged()
    { 
        feedRateText.text = string.Format(formatText, feedRateSlider.value*25);
        feedRateValue = (int)feedRateSlider.value*25;
    }
    public void BoilUpChanged()
    {
        boilUpRatioText.text = string.Format(formatText, 2.50f * (int)boilUpRatioSlider.value);
        boilUpRatioValue = 2.50f * (int)boilUpRatioSlider.value;
    }
    public void RefluxChanged()
    {
        refluxRatioText.text = string.Format(formatText, 2.50f * (int)refluxRatioSlider.value);
        refluxRatioValue = 2.50f * (int)refluxRatioSlider.value;
    }

    public void StartSimulation()
    {
        SceneManager.LoadScene("VRSimulationScene");
        Debug.Log("tray no:");
        Debug.Log(trayNumberValue);
        Debug.Log("feed pos:");
        Debug.Log(feedPositionValue);
        Debug.Log("feed rate:");
        Debug.Log(feedRateValue);
        Debug.Log("boil up:");
        Debug.Log(boilUpRatioValue);
        Debug.Log("reflux ratio:");
        Debug.Log(refluxRatioValue);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("VRMainMenuScene");
    }
}
