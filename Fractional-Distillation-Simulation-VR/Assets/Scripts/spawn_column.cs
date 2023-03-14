using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_column : MonoBehaviour
{
    public GameObject columnPrefab, rightTrayPrefab, leftTrayPrefab,
        feedPrefab, reboilerPrefab, condenserPrefab;
    public int trayNumber, feedPosition;
    public float condenserYPos;
    public const float SCALE = 0.001f;

    //public static Vector3Int worldViewBottomCoord = new Vector3Int(0, 0, 0), worldViewTopCoord;
    private int i;
    void Start()
    {
        trayNumber = SliderOptionsMenu.trayNumberValue;
        feedPosition = SliderOptionsMenu.feedPositionValue;

        if (trayNumber < 6) { trayNumber = 6; }
        else if (trayNumber > 20) { trayNumber = 20; }

        if (feedPosition >= trayNumber) { feedPosition = trayNumber - 1; }
        else if (feedPosition < 1) { feedPosition = 1; }

        //GameObject reboilerInstance = (GameObject)Instantiate(reboilerPrefab, transform);
        //reboilerInstance.transform.localPosition = new Vector3(0,467*SCALE,0);
        reboilerPrefab.transform.localPosition = new Vector3(0, 467 * SCALE, 0);


        for (i = 0; i < trayNumber; i++) {
            if (i % 2 == 0) {
                GameObject rightTrayInstance = (GameObject)Instantiate(rightTrayPrefab, transform);
                rightTrayInstance.transform.localPosition = new Vector3(0, (467 + i * 120) * SCALE, 0);
            }
            else
            {
                GameObject leftTrayInstance = (GameObject)Instantiate(leftTrayPrefab, transform);
                leftTrayInstance.transform.localPosition = new Vector3(0, (467 + i * 120) * SCALE, 0);
            }
            if (i == trayNumber - feedPosition - 1) {
                //GameObject feedInstance = (GameObject)Instantiate(feedPrefab, transform);
                //feedInstance.transform.localPosition = new Vector3(0, (467 + i * 100 + (i+1) * 20) * SCALE, 0);
                feedPrefab.transform.localPosition = new Vector3(0, (467 + i * 100 + (i + 1) * 20) * SCALE, 0);
            }
            else if (i < trayNumber - 1)
            {
                GameObject columnInstance = (GameObject)Instantiate(columnPrefab, transform);
                columnInstance.transform.localPosition = new Vector3(0, (467 + i * 100 + (i + 1) * 20) * SCALE, 0);
            }
        }
        //GameObject condenserInstance = (GameObject)Instantiate(condenserPrefab, transform);
        //condenserInstance.transform.localPosition = new Vector3(0, (487 + (trayNumber - 1) * 120) * SCALE, 0);
        condenserPrefab.transform.localPosition = new Vector3(0, (487 + (trayNumber - 1) * 120) * SCALE, 0);
        //float heightofCol = condenserInstance.transform.localPosition.y + ((756.24f - (467f - 436f)) * SCALE);
        float heightofCol = condenserPrefab.transform.localPosition.y + ((756.24f - (467f - 436f)) * SCALE);
        //condenserYPos = condenserInstance.transform.position.y;
        condenserYPos = condenserPrefab.transform.position.y;
    }

    
}
