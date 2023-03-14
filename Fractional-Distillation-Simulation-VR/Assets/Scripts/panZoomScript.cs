using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panZoomScript : MonoBehaviour
{
    public Camera cam;
    public GameObject sphere;

    

    private Vector3 startPos;
    private Vector3 direction;
    private Vector3 directionWV;
    private Vector3 newCamPos;

    private Touch touch;
    private Touch touch2;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        startPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.transform.position.z));
                        GameObject sphereinst = (GameObject)Instantiate(sphere);
                        sphereinst.transform.position = startPos;
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        GameObject sphereinst = (GameObject)Instantiate(sphere);
                        sphereinst.transform.position = startPos;
                        sphereinst.transform.localScale += new Vector3(5, 5, 5
                            );
                        direction = startPos - cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.transform.position.z));
                        transform.position += new Vector3(direction.x, direction.y, 0);
                        /*
                        newCamPos = cam.transform.position;
                        newCamPos += new Vector3(directionWV.x, directionWV.y, 0);
                        cam.transform.position = newCamPos;
                        */
                        startPos = touch.position;
                        break;
                    }
            }
        }
        /*
        else if (Input.touchCount > 1)
        {
            touch = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);
        }
        */
    }
}
