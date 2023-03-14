using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newsplite_task : MonoBehaviour {
    public GameObject caculator0, caculator1, caculator2, caculator3, caculator4,
        caculator5, caculator6, caculator7, caculator8, caculator9, caculator10,
        caculator11, caculator12, caculator13, caculator14, caculator15, caculator16,
        caculator17, caculator18, caculator19, caculator20, caculator21, caculator22, caculator23,
        caculator24, caculator25, caculator26, caculator27, caculator28, caculator29, caculator30,
        caculator31, caculator32, caculator33, caculator34, caculator35, caculator36, caculator37,
        caculator38, caculator39, caculator40, caculator41, caculator42, caculator43, caculator44,
        caculator45, caculator46, caculator47, caculator48, caculator49,
        caculator50, caculator51, caculator52, caculator53, caculator54,
        caculator55, caculator56, caculator57, caculator58, caculator59, caculator60,
        caculator61, caculator62, caculator63, caculator64, caculator65, caculator66,
        caculator67, caculator68, caculator69, caculator70, caculator71, caculator72, caculator73,
        caculator74, caculator75, caculator76, caculator77, caculator78, caculator79, caculator80,
        caculator81, caculator82, caculator83, caculator84, caculator85, caculator86, caculator87,
        caculator88, caculator89, caculator90, caculator91, caculator92, caculator93, caculator94,
        caculator95, caculator96, caculator97, caculator98, caculator99;

    // public InputField FX;
    public float average;
    //float Xf; 
    // Use this for initialization
    void Start()
    {
        /**
        average = (0.9f - 0.5f) / 100;
        caculator0.GetComponent<U_G_2>().offset = 0;
        caculator1.GetComponent<U_G_2>().offset = average;
        caculator2.GetComponent<U_G_2>().offset = 2 * average;
        caculator3.GetComponent<U_G_2>().offset = 3 * average;
        caculator4.GetComponent<U_G_2>().offset = 4 * average;
        caculator5.GetComponent<U_G_2>().offset = 5 * average;
        caculator6.GetComponent<U_G_2>().offset = 6 * average;
        caculator7.GetComponent<U_G_2>().offset = 7 * average;
        caculator8.GetComponent<U_G_2>().offset = 8 * average;
        caculator9.GetComponent<U_G_2>().offset = 9 * average;
        caculator10.GetComponent<U_G_2>().offset = 10 * average;
        caculator11.GetComponent<U_G_2>().offset = 11 * average;
        caculator12.GetComponent<U_G_2>().offset = 12 * average;
        caculator13.GetComponent<U_G_2>().offset = 13 * average;
        caculator14.GetComponent<U_G_2>().offset = 14 * average;
        caculator15.GetComponent<U_G_2>().offset = 15 * average;
        caculator16.GetComponent<U_G_2>().offset = 16 * average;
        caculator17.GetComponent<U_G_2>().offset = 17 * average;
        caculator18.GetComponent<U_G_2>().offset = 18 * average;
        caculator19.GetComponent<U_G_2>().offset = 19 * average;
        caculator20.GetComponent<U_G_2>().offset = 20 * average;
        caculator21.GetComponent<U_G_2>().offset = 21 * average;
        caculator22.GetComponent<U_G_2>().offset = 22 * average;
        caculator23.GetComponent<U_G_2>().offset = 23 * average;
        caculator24.GetComponent<U_G_2>().offset = 24 * average;
        caculator25.GetComponent<U_G_2>().offset = 25 * average;
        caculator26.GetComponent<U_G_2>().offset = 26 * average;
        caculator27.GetComponent<U_G_2>().offset = 27 * average;
        caculator28.GetComponent<U_G_2>().offset = 28 * average;
        caculator29.GetComponent<U_G_2>().offset = 29 * average;
        caculator30.GetComponent<U_G_2>().offset = 30 * average;
        caculator31.GetComponent<U_G_2>().offset = 31 * average;
        caculator32.GetComponent<U_G_2>().offset = 32 * average;
        caculator33.GetComponent<U_G_2>().offset = 33 * average;
        caculator34.GetComponent<U_G_2>().offset = 34 * average;
        caculator35.GetComponent<U_G_2>().offset = 35 * average;
        caculator36.GetComponent<U_G_2>().offset = 36 * average;
        caculator37.GetComponent<U_G_2>().offset = 37 * average;
        caculator38.GetComponent<U_G_2>().offset = 38 * average;
        caculator39.GetComponent<U_G_2>().offset = 39 * average;
        caculator40.GetComponent<U_G_2>().offset = 40 * average;
        caculator41.GetComponent<U_G_2>().offset = 41 * average;
        caculator42.GetComponent<U_G_2>().offset = 42 * average;
        caculator43.GetComponent<U_G_2>().offset = 43 * average;
        caculator44.GetComponent<U_G_2>().offset = 44 * average;
        caculator45.GetComponent<U_G_2>().offset = 45 * average;
        caculator46.GetComponent<U_G_2>().offset = 46 * average;
        caculator47.GetComponent<U_G_2>().offset = 47 * average;
        caculator48.GetComponent<U_G_2>().offset = 48 * average;
        caculator49.GetComponent<U_G_2>().offset = 49 * average;
        caculator50.GetComponent<U_G_2>().offset = 50 * average;
        caculator51.GetComponent<U_G_2>().offset = 51 * average;
        caculator52.GetComponent<U_G_2>().offset = 52 * average;
        caculator53.GetComponent<U_G_2>().offset = 53 * average;
        caculator54.GetComponent<U_G_2>().offset = 54 * average;
        caculator55.GetComponent<U_G_2>().offset = 55 * average;
        caculator56.GetComponent<U_G_2>().offset = 56 * average;
        caculator57.GetComponent<U_G_2>().offset = 57 * average;
        caculator58.GetComponent<U_G_2>().offset = 58 * average;
        caculator59.GetComponent<U_G_2>().offset = 59 * average;
        caculator60.GetComponent<U_G_2>().offset = 60 * average;
        caculator61.GetComponent<U_G_2>().offset = 61 * average;
        caculator62.GetComponent<U_G_2>().offset = 62 * average;
        caculator63.GetComponent<U_G_2>().offset = 63 * average;
        caculator64.GetComponent<U_G_2>().offset = 64 * average;
        caculator65.GetComponent<U_G_2>().offset = 65 * average;
        caculator66.GetComponent<U_G_2>().offset = 66 * average;
        caculator67.GetComponent<U_G_2>().offset = 67 * average;
        caculator68.GetComponent<U_G_2>().offset = 68 * average;
        caculator69.GetComponent<U_G_2>().offset = 69 * average;
        caculator70.GetComponent<U_G_2>().offset = 70 * average;
        caculator71.GetComponent<U_G_2>().offset = 71 * average;
        caculator72.GetComponent<U_G_2>().offset = 72 * average;
        caculator73.GetComponent<U_G_2>().offset = 73 * average;
        caculator74.GetComponent<U_G_2>().offset = 74 * average;
        caculator75.GetComponent<U_G_2>().offset = 75 * average;
        caculator76.GetComponent<U_G_2>().offset = 76 * average;
        caculator77.GetComponent<U_G_2>().offset = 77 * average;
        caculator78.GetComponent<U_G_2>().offset = 78 * average;
        caculator79.GetComponent<U_G_2>().offset = 79 * average;
        caculator80.GetComponent<U_G_2>().offset = 80 * average;
        caculator81.GetComponent<U_G_2>().offset = 81 * average;
        caculator82.GetComponent<U_G_2>().offset = 82 * average;
        caculator83.GetComponent<U_G_2>().offset = 83 * average;
        caculator84.GetComponent<U_G_2>().offset = 84 * average;
        caculator85.GetComponent<U_G_2>().offset = 85 * average;
        caculator86.GetComponent<U_G_2>().offset = 86 * average;
        caculator87.GetComponent<U_G_2>().offset = 87 * average;
        caculator88.GetComponent<U_G_2>().offset = 88 * average;
        caculator89.GetComponent<U_G_2>().offset = 89 * average;
        caculator90.GetComponent<U_G_2>().offset = 90 * average;
        caculator91.GetComponent<U_G_2>().offset = 91 * average;
        caculator92.GetComponent<U_G_2>().offset = 92 * average;
        caculator93.GetComponent<U_G_2>().offset = 93 * average;
        caculator94.GetComponent<U_G_2>().offset = 94 * average;
        caculator95.GetComponent<U_G_2>().offset = 95 * average;
        caculator96.GetComponent<U_G_2>().offset = 96 * average;
        caculator97.GetComponent<U_G_2>().offset = 97 * average;
        caculator98.GetComponent<U_G_2>().offset = 98 * average;
        caculator99.GetComponent<U_G_2>().offset = 99 * average;
        */
    }
}
