using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{

    public AudioClip[] soundtracks;
    private AudioSource Speaker;
    public float Interval = 30f;

    private float counter;
    private float songLength;

    private bool index;
    

    // Update is called once per frame

    private void Start()
    {
        counter = Interval;
        Speaker = GetComponent<AudioSource>();
    }

    private void Update()
    {
                songLength -= Time.deltaTime;

        if (songLength < 0f)
        {
            counter -= Time.deltaTime;
            if(counter < 0f)
            {
                playSong();
                counter = Interval;
            }
        }
    }
    

    

    private void playSong()
    {
        if (index == true)
        {
            Speaker.clip = soundtracks[0];
            songLength = soundtracks[0].length;
            Speaker.Play();
            index = false;
        }
        else
        {
            Speaker.clip = soundtracks[1];
            songLength = soundtracks[1].length;
            Speaker.Play();
            index = true;
        }
    }
}
