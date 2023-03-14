using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class userYDirectionMovement : MonoBehaviour
{
    public Camera cam;
    public float movementIncrement = 0.025f;
    private float minY = -1.2f;
    private float maxY = 1.2f;
    private int trayNumber;
    // Start is called before the first frame update
    void Start()
    {
        trayNumber = SliderOptionsMenu.trayNumberValue;

        if (trayNumber < 6) { trayNumber = 6; }
        else if (trayNumber > 20) { trayNumber = 20; }

        maxY = 0.001f * ((trayNumber - 1) * 120 + 800);

        List<InputDevice> RHdevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, RHdevices);

        List<InputDevice> LHdevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, LHdevices);

        foreach (var item in RHdevices)
        {
            //Debug.Log(item.name + item.characteristics);
            StartCoroutine(xDirectionMovement(item));
            StartCoroutine(zDirectionMovement(item));
        }

        foreach (var item in LHdevices) {
            //Debug.Log(item.name + item.characteristics);
            StartCoroutine(yDirectionMovement(item));
        }
    }

    private IEnumerator yDirectionMovement(InputDevice controller)
    {
        while (true) {
            controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickVector);
            float yValue = joystickVector.y;
            //Debug.Log(controller.name + yValue);
            if (yValue != 0)
            {
                Vector3 currentPosition = transform.position;
                if (currentPosition.y < minY)
                {
                    currentPosition.y = minY;
                    transform.position = currentPosition;
                }
                else if (currentPosition.y > maxY)
                {
                    currentPosition.y = maxY;
                    transform.position = currentPosition;
                }
                currentPosition.y += yValue * movementIncrement;
                transform.position = currentPosition;
            }
            yield return null;
        }
    }

    private IEnumerator zDirectionMovement(InputDevice controller)
    {
        while (true)
        {
            controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickVector);
            float zValue = joystickVector.y;
            //Debug.Log(controller.name + yValue);
            if (zValue != 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition += cam.transform.forward * zValue * movementIncrement * 0.5f;
                transform.position = currentPosition;
            }
            yield return null;
        }

    }

    private IEnumerator xDirectionMovement(InputDevice controller)
    {
        while (true)
        {
            controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickVector);
            float xValue = joystickVector.x;
            //Debug.Log(controller.name + yValue);
            if (xValue != 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition += cam.transform.right * xValue * movementIncrement * 0.5f;
                transform.position = currentPosition;
            }
            yield return null;
        }

    }
}
