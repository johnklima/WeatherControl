using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound2 : MonoBehaviour
{
    public AudioClip AmbientSound;
    public float Volume;
    public AudioSource audio;
    public float startCount = 10f;
    public float currentCount = 10f;

    // Update is called once per frame
    void Update()
    {
        currentCount -= Time.deltaTime;

        if (currentCount <= 0)
        {
            audio.PlayOneShot(AmbientSound, Volume);
            currentCount = startCount;
        }
    }
}
