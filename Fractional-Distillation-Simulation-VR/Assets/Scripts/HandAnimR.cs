using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimR : MonoBehaviour
{
    public GameObject handModelPrefab;
    private GameObject spawnedHandInstance;
    private Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        GameObject spawnedHandInstance = Instantiate(handModelPrefab, transform);

        foreach (var item in devices)
        {
            StartCoroutine(handAnim(item, spawnedHandInstance));
        }
    }

    private IEnumerator handAnim(InputDevice controller, GameObject spawnedHandInstance)
    {
        Animator handAnimator = spawnedHandInstance.GetComponent<Animator>();
        while (true)
        {
            if (controller.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handAnimator.SetFloat("Grip", gripValue);
            }
            else
            {
                handAnimator.SetFloat("Grip", 0);
            }
            if (controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handAnimator.SetFloat("Trigger", triggerValue);
            }
            else
            {
                handAnimator.SetFloat("Trigger", 0);
            }
            Debug.Log(controller.name + gripValue);
            yield return null;
        }
    }
}
