using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleMovement : MonoBehaviour
{
    public float totalDisplace = 7f, yDisplace = 0.3f, 
        radiusDisplace = 3f,
        absangularDisplace = 0.25f, angle = 0f;
    public float SCALE = 1f;
    private float angularDisplace;
    private float modifier;

    // Start is called before the first frame update
    void Start()
    {
        SCALE = spawn_column.SCALE;
        totalDisplace *= SCALE;
        yDisplace *= SCALE;
        radiusDisplace *= SCALE;
        modifier = Random.Range(-1f, 1f);
        if (modifier >= 0) { angularDisplace = Random.Range(0.5f, 1.5f)*absangularDisplace; }
        else { angularDisplace = -Random.Range(0.5f, 1.5f) * absangularDisplace; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3
            (radiusDisplace * Mathf.Cos(angularDisplace+angle)-radiusDisplace *Mathf.Cos(angle), 
            yDisplace, radiusDisplace * Mathf.Sin(angularDisplace+angle)-radiusDisplace * Mathf.Sin(angle)));
        totalDisplace -= yDisplace;
        angle += angularDisplace;
        radiusDisplace += 0.01f * radiusDisplace;
        //if (totalDisplace < 10f)
        //{
            //float bubbleColor = GetComponent<Renderer>().material.SetFloat("Vector1_6C6E6093",);
            //if (bubbleColor.a > 0)
            //{
            //    bubbleColor.a -= fadeSpeed;
            //    GetComponent<Renderer>()material.shader = bubbleColor;
            //}
        //}
        if (totalDisplace<0)
        {
            Destroy(gameObject);
        }
    }
}
