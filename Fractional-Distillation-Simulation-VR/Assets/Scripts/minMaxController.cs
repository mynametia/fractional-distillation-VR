using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minMaxController : MonoBehaviour
{
    public Slider feedPosSlider;
    public Slider trayNoSlider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        feedPosSlider.maxValue = trayNoSlider.value - 1;
    }
}
