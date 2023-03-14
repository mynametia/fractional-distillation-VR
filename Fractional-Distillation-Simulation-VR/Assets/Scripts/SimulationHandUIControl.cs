using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SimulationHandUIControl : MonoBehaviour
{
    public GameObject ExpCondCanvas;
    public GameObject raycastLine;

    bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            //Debug.Log(item.name + item.characteristics);
            StartCoroutine(toggleExpCond(item));
        }
    }

    private IEnumerator toggleExpCond(InputDevice controller) 
    {
        while (true) 
        {
            controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            if (triggerValue > 0.1f)
            {
                ExpCondCanvas.SetActive(true);
                raycastLine.SetActive(false);

            }
            else
            {
                ExpCondCanvas.SetActive(false);
                raycastLine.SetActive(true);
            }
            yield return null;
        }
    }
}
