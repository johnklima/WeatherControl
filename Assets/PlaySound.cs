using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioClip AmbientSound;
    public float Volume;
    public AudioSource audio;
    public float startCount = 15f;
    public float currentCount = 15f;

    // Update is called once per frame
    void Update()
    {
        currentCount -= Time.deltaTime;

        if(currentCount <= 0)
        {
            audio.PlayOneShot(AmbientSound, Volume);
            currentCount = startCount;
        }


    }
}
