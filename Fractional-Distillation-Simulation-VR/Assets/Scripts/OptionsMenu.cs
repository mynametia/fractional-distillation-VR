using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    private List<int> trayNumber = new List<int>();
    private List<int> feedPosition = new List<int>();
    private List<int> feedRate = new List<int>();
    private List<float> boilUpRatio = new List<float>();
    private List<float> refluxRatio = new List<float>();

    public TextMeshProUGUI trayNumberText;
    public TextMeshProUGUI feedPositionText;
    public TextMeshProUGUI feedRateText;
    public TextMeshProUGUI boilUpRatioText;
    public TextMeshProUGUI refluxRatioText;

    public static int trayNumberValue = 0;
    public static int feedPositionValue = 0;
    public static int feedRateValue = 0;
    public static float boilUpRatioValue = 0;
    public static float refluxRatioValue = 0;
    void Start()
    {
        for (int i = 6; i <= 20; i++) {
            trayNumber.Add(i);
        }
        for (int i = 1; i < 20; i++)
        {
            feedPosition.Add(i);
        }
        feedRate.Add(50);
        feedRate.Add(75);
        feedRate.Add(100);

        boilUpRatio.Add(2.5f);
        boilUpRatio.Add(5f);
        boilUpRatio.Add(10f);

        refluxRatio.Add(0.1f);
        refluxRatio.Add(1f);
        refluxRatio.Add(10f);

        trayNumberText.text = trayNumber[0].ToString();
        feedPositionText.text = feedPosition[0].ToString();
        feedRateText.text = feedRate[0].ToString();
        boilUpRatioText.text = boilUpRatio[0].ToString();
        refluxRatioText.text = refluxRatio[0].ToString();
    }
    void Update()
    {
        Int32.TryParse(trayNumberText.text, out trayNumberValue);
        Int32.TryParse(feedPositionText.text, out feedPositionValue);
        Int32.TryParse(feedRateText.text, out feedRateValue);
        float.TryParse(boilUpRatioText.text, out boilUpRatioValue);
        float.TryParse(refluxRatioText.text, out refluxRatioValue);
    }

    //tray number buttons
    public void trayNumberLeft() 
    {
        int index = trayNumber.IndexOf(trayNumberValue);
        if (index == 0)
        {
            trayNumberText.text = trayNumber[trayNumber.Count - 1].ToString();
        }
        else 
        {
            trayNumberText.text = trayNumber[index - 1].ToString();
        }
    }
    public void trayNumberRight()
    {
        int index = trayNumber.IndexOf(trayNumberValue);
        if (index == trayNumber.Count - 1)
        {
            trayNumberText.text = trayNumber[0].ToString();
        }
        else
        {
            trayNumberText.text = trayNumber[index + 1].ToString();
        }
    }

    //feed position buttons
    public void feedPositionLeft() 
    {
        int index = feedPosition.IndexOf(feedPositionValue);
        if (index == 0)
        {
            feedPositionText.text = feedPosition[trayNumberValue - 2].ToString();
        }
        else
        {
            feedPositionText.text = feedPosition[index - 1].ToString();
        }
    }
    public void feedPositionRight()
    {
        int index = feedPosition.IndexOf(feedPositionValue);
        if (index >= trayNumberValue - 2)
        {
            
            feedPositionText.text = feedPosition[0].ToString();
        }
        else
        {
            feedPositionText.text = feedPosition[index + 1].ToString();
        }

    }

    //feed rate buttons
    public void feedRateLeft()
    {
        int index = feedRate.IndexOf(feedRateValue);
        if (index == 0)
        {
            feedRateText.text = feedRate[2].ToString();
        }
        else
        {
            feedRateText.text = feedRate[index - 1].ToString();
        }
    }
    public void feedRateRight()
    {
        int index = feedRate.IndexOf(feedRateValue);
        if (index == 2)
        {

            feedRateText.text = feedRate[0].ToString();
        }
        else
        {
            feedRateText.text = feedRate[index + 1].ToString();
        }

    }

    //boil up ratio buttons
    public void boilUpLeft()
    {
        int index = boilUpRatio.IndexOf(boilUpRatioValue);
        if (index == 0)
        {
            boilUpRatioText.text = boilUpRatio[2].ToString();
        }
        else
        {
            boilUpRatioText.text = boilUpRatio[index - 1].ToString();
        }
    }
    public void boilUpRight()
    {
        int index = boilUpRatio.IndexOf(boilUpRatioValue);
        if (index == 2)
        {

            boilUpRatioText.text = boilUpRatio[0].ToString();
        }
        else
        {
            boilUpRatioText.text = boilUpRatio[index + 1].ToString();
        }

    }

    //reflux ratio buttons
    public void refluxLeft()
    {
        int index = refluxRatio.IndexOf(refluxRatioValue);
        if (index == 0)
        {
            refluxRatioText.text = refluxRatio[2].ToString();
        }
        else
        {
            refluxRatioText.text = refluxRatio[index - 1].ToString();
        }
    }
    public void refluxRight()
    {
        int index = refluxRatio.IndexOf(refluxRatioValue);
        if (index == 2)
        {

            refluxRatioText.text = refluxRatio[0].ToString();
        }
        else
        {
            refluxRatioText.text = refluxRatio[index + 1].ToString();
        }

    }
    public void StartSimulation ()
    {
        SceneManager.LoadScene("SimulationScene");
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
}
