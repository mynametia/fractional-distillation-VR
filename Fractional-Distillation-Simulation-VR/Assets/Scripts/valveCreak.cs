using System.Collections;
using UnityEngine;

public class valveCreak : MonoBehaviour
{
    public AudioClip[] valveSounds = new AudioClip[3];
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    public void playValveCreak()
    {
        GetComponent<AudioSource>().clip = valveSounds[Random.Range(0, 3)];
        GetComponent<AudioSource>().Play();
    }
}
