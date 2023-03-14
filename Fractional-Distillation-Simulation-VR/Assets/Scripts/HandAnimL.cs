using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimL : MonoBehaviour
{
    public GameObject handModelPrefab;
    private GameObject spawnedHandInstance;
    private Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        GameObject spawnedHandInstance = Instantiate(handModelPrefab, transform);

        foreach (var item in devices)
        {
            //Debug.Log(item.name + item.characteristics);
            StartCoroutine(handAnim(item, spawnedHandInstance));
        }
    }

    private IEnumerator handAnim(InputDevice controller, GameObject spawnedHandInstance)
    {
        Animator handAnimator = spawnedHandInstance.GetComponent<Animator>();
        while (true)
        {
            controller.TryGetFeatureValue(CommonUsages.grip, out float gripValue);
            controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

            handAnimator.SetFloat("Grip", gripValue);
            handAnimator.SetFloat("Trigger", triggerValue);

            yield return null;
        }
    }
}
