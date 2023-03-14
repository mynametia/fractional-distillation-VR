using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_G20trays : MonoBehaviour
{

    //Reflux Ratio, R
    //Reboiler Ratio, Vb;
    //Feed composition of ethanol, Xf
    //compositio of ethanol in vapour state, Y
    //compostion of ethanol in liquid state, X
    public float offset = 0, feedR, Fd, Fb,
        Xf, R, Vb, xD;
    float xB;
    float D;
    // Use this for initialization
    //changes below
    public int trayNumber = 6, feedPosition = 4;
    //variableList contains variables in the order Y1, X1, Y2, ... Yn, Xn
    public List<float> variableList;
    public bool calculating;

    void Start()
    {
        //trayNumber = 20;
        //conditions for feedPosition value: 1 <= feedPostion < trayNumber
        //feedPosition = 10;
        calculating = true;

        Xf = 0.5f;
        Vb = 5;
        R = 1;
        xD = 0.69951140722275f + offset;
        //opt = feed_position.GetComponent<swap2_position>().level;
        feedR = 100;
        caculator();

        /*
        Fd = (0.5f - xB) * feedR / (xD - xB);
        Fb = (feedR - Fd);
        int j;
        for (j = 0; j <= trayNumber * 2; j++)
        {
            if (j % 2 == 0)
            {
                Debug.Log("Y" + (j / 2) + " :" + variableList[j]);
            }
            else
            {
                Debug.Log("X" + (j / 2) + " :" + variableList[j]);
            }
        }
        */

        
        while (calculating) {
            if (D < 0.01 && xD < 1)
            {
                Fd = (0.5f - xB) * feedR / (xD - xB);
                Fb = (feedR - Fd);

                Debug.Log("feedrate: " + feedR);
                Debug.Log("Fd_rate: " + Fd);
                Debug.Log("Fb_rate: " + Fb);

                int j;
                for (j = 0; j <= trayNumber * 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        Debug.Log("Y" + (j/2) + " :" + variableList[j]);
                    }
                    else
                    {
                        Debug.Log("X" + (j/2) + " :" + variableList[j]);
                    }
                }
                Debug.Log(variableList.Count);
                calculating = false;
            }
            else
            {
                xD = xD + 0.0001f;
                caculator();
                if (xD >= 0.9)
                {
                    Debug.Log("Error!");
                    calculating = false;

                }
            }
        }
        

    }
    float EEE(float Y)
    {
        //vapor liquid equilibrium eqn: x = (Ay^4 + By^3 + Cy^2 + Dy + E)/(y^4 + Fy^3 + Gy^2 + Hy + I)
        float E;
        E = (0.2257f * Mathf.Pow(Y, 4) - 0.1482f * Mathf.Pow(Y, 3) - 0.02055f * Mathf.Pow(Y, 2) + 0.02337f * Y + 0.0006006f) /
            (Mathf.Pow(Y, 4) - 2.998f * Mathf.Pow(Y, 3) + 3.744f * Mathf.Pow(Y, 2) - 2.119f * Y + 0.4538f);
        return E;
    }
    float RRR(float X)
    {
        //rectifying equation: y(n+1) = R/(R+1)*x(n) + x(D)/(R+1)
        float y;
        y = R / (R + 1) * X + (xD / (R + 1));
        return y;
    }
    float XB()
    {
        //equation to find xB for stripping equations
        xB = ((Vb + 1) / Vb * Xf - R * Xf / (R + 1) - xD / (R + 1)) * Vb;
        return xB;
    }
    float SSS(float X)
    {
        //stripping equation to find y(m+1) from x(m)
        float y;
        y = (Vb + 1) / Vb * X - xB / Vb;
        return y;
    }
    void caculator()
    {
        int i;
        float Yprev = 0, Xprev = 0;
        for (i = 0; i <= trayNumber; i++) {
            if (i == feedPosition + 1) {
                XB();
            }

            if (i == 0)
            {
                Yprev = xD;
            }
            else if (i <= feedPosition)
            {
                Yprev = RRR(Xprev);
            }
            else 
            {
                Yprev = SSS(Xprev);
            }

            variableList.Add(Yprev);
            Xprev = EEE(Yprev);
            variableList.Add(Xprev);

            if (i == trayNumber) 
            {
                D = Mathf.Abs(xB - Xprev);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
