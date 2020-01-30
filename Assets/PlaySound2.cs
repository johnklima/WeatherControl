using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound2 : MonoBehaviour
{

    public AudioClip AmbientSound;
    private AudioSource Audio;
    public float startCount = 15f;
    private float currentCount;


    private void Start()
    {
        currentCount = startCount;
        Audio = GetComponent<AudioSource>();
        Audio.clip = AmbientSound;
    }
    // Update is called once per frame
    void Update()
    {
        currentCount -= Time.deltaTime;

        if (currentCount <= 0)
        {
            Audio.Play();
            currentCount = startCount;
        }
    }
}
