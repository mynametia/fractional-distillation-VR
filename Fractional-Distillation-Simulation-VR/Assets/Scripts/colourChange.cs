using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{
    public float liqCon = 50f;

    private Color OgColour;
    private Color OgGlow;

    private Color firstColour;
    private Color firstGlow;

    private Color endColour;
    private Color endGlow;

    Renderer rend;
    private float speed = 0.03f;
    private float t = 0.01f;

    //colour change for rippling shader
    void Start()
    {
        rend = GetComponent<Renderer>();
        OgColour = rend.material.GetVector("Color_96F8F179");
        OgGlow = rend.material.GetVector("Color_EEA91FF8");

        firstColour = OgColour;
        firstGlow = OgGlow;

        //0 ethanol concen, normal blue. 100 ethanol con, orange. 50 green.
        if (liqCon > 0.5f)
        {
            if (liqCon > 1) { liqCon = 1; }
            endColour.b = 0;
            endGlow.b = 0;

            endColour.r = OgColour.r + (1 - OgColour.r) * ((liqCon / 0.5f) - 1) * 2;
            endGlow.r = OgGlow.r + (1 - OgColour.r) * ((liqCon / 0.5f) - 1) * 2;

            endColour.g = OgColour.g * (2 - (liqCon / 0.5f));
            endGlow.g = OgGlow.g * (2 - (liqCon / 0.5f));
        }
        else
        {
            if (liqCon < 0) { liqCon = 0; }
            endColour.b = 0.792f * (1 - (liqCon / 0.5f));
            endGlow.b = 0.792f * (1 - (liqCon / 0.5f));
            
            endColour.r = OgColour.r;
            endGlow.r = OgGlow.r;

            endColour.g = OgColour.g;
            endGlow.g = OgGlow.g;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetVector("Color_96F8F179", Color.Lerp(firstColour, endColour, t * speed));
        rend.material.SetVector("Color_EEA91FF8", Color.Lerp(firstGlow, endGlow, t * speed));
        t += 1;
    }
}
