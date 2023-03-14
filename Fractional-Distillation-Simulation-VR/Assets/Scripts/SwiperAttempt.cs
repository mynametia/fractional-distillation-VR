using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiperAttempt : MonoBehaviour
{
    private Touch touch = new Touch();
    private Touch touch2 = new Touch();

    public Camera cam;
    
    private Vector3 centre;
    private Vector3 xAxis;
    private Vector3 yAxis;
    private Vector3 ogPos;

    private Vector2 startPos;
    private Vector2 startPos2;
    private Vector2 finPos;
    private Vector2 displacement;
    private Vector2 displacement2;
    private Vector2 panDisplacement;

    private float radius;
    private float rotXSpd;
    private float rotYSpd;

    private float startDist;
    private float finDist;
    private float ogZoom;
    private float finZoom;
    private float zoomSpd = 8;
    private float panSpd = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
        xAxis = new Vector3(1f, 0f, 0f);
        yAxis = new Vector3(0f, 1f, 0f);


        centre = new Vector3(0f, cam.transform.position.y, 0f);
        ogPos = cam.transform.position;
        //radius = Mathf.Abs(cam.transform.position.z);
        ogZoom = cam.orthographicSize;
        finZoom = ogZoom;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                finPos = touch.position;
                displacement = finPos - startPos;
                rotXSpd = Mathf.Abs(displacement.x) * 2;
                rotYSpd = Mathf.Abs(displacement.y) * 2;
                if (displacement.x > 0)
                {
                    if (Vector3.Dot(cam.transform.up, yAxis) >= 0)
                    {
                        cam.transform.RotateAround(centre, yAxis, rotXSpd * Time.deltaTime);
                    }
                    else
                    {
                        cam.transform.RotateAround(centre, -yAxis, rotXSpd * Time.deltaTime);
                    }

                }
                else if (displacement.x < 0)
                {
                    if (Vector3.Dot(cam.transform.up, yAxis) >= 0)
                    {
                        cam.transform.RotateAround(centre, -yAxis, rotXSpd * Time.deltaTime);
                    }
                    else
                    {
                        cam.transform.RotateAround(centre, yAxis, rotXSpd * Time.deltaTime);
                    }
                }
                if (displacement.y > 0)
                {
                    if (Vector3.Dot(cam.transform.right, xAxis) >= 0)
                    {
                        cam.transform.RotateAround(centre, -xAxis, rotYSpd * Time.deltaTime);
                    }
                    else
                    {
                        cam.transform.RotateAround(centre, xAxis, rotYSpd * Time.deltaTime);
                    }
                }
                else if (displacement.y < 0)
                {
                    if (Vector3.Dot(cam.transform.right, xAxis) >= 0)
                    {
                        cam.transform.RotateAround(centre, xAxis, rotYSpd * Time.deltaTime);
                    }
                    else
                    {
                        cam.transform.RotateAround(centre, -xAxis, rotYSpd * Time.deltaTime);
                    }
                }
                startPos = finPos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {

            }
        }
        else if (Input.touchCount >= 2)
        {
            touch = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Began) 
            { 
                startPos = touch.position;
                startDist = (startPos2 - startPos).magnitude;
            }
            if (touch2.phase == TouchPhase.Began)
            {
                startPos2 = touch2.position;
                startDist = (startPos2 - startPos).magnitude;
            }
            if (touch.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) 
            {
                //zoom
                finDist = (touch2.position - touch.position).magnitude;
                if (finDist > startDist)
                {
                    //zoom in
                    if (finZoom > 150)
                    {
                        finZoom -= (finDist - startDist) * 1;

                        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, finZoom, Time.deltaTime * zoomSpd);
                    }
                    startDist = finDist;
                }
                else if (finDist < startDist) 
                {
                    //zoom out
                    if (finZoom < ogZoom + 200) 
                    {
                        finZoom += (startDist - finDist) * 1;
                        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, finZoom, Time.deltaTime * zoomSpd);
                    }
                    startDist = finDist;
                }

                //pan
                displacement = touch.position - startPos;
                displacement2 = touch2.position - startPos2;
                panDisplacement = displacement + displacement2;

                //if (cam.transform.position.x <= 1200 && cam.transform.position.x >= -650 
                //    && cam.transform.position.y <= (GetComponent<cameraPosition>().yTopWorldView/2) && cam.transform.position.y >= (-GetComponent<cameraPosition>().yTopWorldView / 2)
                //    && cam.transform.position.z <= 0 && cam.transform.position.z >= -4000)
                //{
                    if (Vector2.Dot(displacement, displacement2) > 0)
                    {
                        //finding the shorter displacement
                        if (displacement.magnitude < displacement2.magnitude) { Vector2 shorterV = displacement; }
                        else { Vector2 shorterV = displacement2; }

                        if (panDisplacement.x != 0)
                        {
                            cam.transform.Translate(panDisplacement.x * cam.transform.right * panSpd);
                        }
                        if (panDisplacement.y != 0)
                        {
                            cam.transform.Translate(-panDisplacement.y * cam.transform.up * panSpd);
                        }
                    }
                //}

                startPos = touch.position;
                startPos2 = touch2.position;
            }
        }
    }
}
