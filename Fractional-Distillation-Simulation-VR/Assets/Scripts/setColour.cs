using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColour : MonoBehaviour
{
    public float liqCon;

    private Color OgColour;
    private Color endColour;

    private Color OgGlow;
    private Color endGlow;

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        OgColour = rend.material.GetVector("Color_8B80C9EC");
        OgGlow = rend.material.GetVector("Color_C0E25124");

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
            endColour.b = 1 - (liqCon / 0.5f);
            endGlow.b = 1 - (liqCon / 0.5f);

            endColour.r = OgColour.r;
            endGlow.r = OgGlow.r;

            endColour.g = OgColour.g;
            endGlow.g = OgGlow.g;
        }

        rend.material.SetVector("Color_8B80C9EC", endColour);
        rend.material.SetVector("Color_C0E25124", endGlow);

    }

}
