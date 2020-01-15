using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private GameObject theSun;
    private Light theSunLight;

    public float DayTime;
    public float NightTime;

    private float currentNightTime;
    private float currentDayTime;

    private bool isDay;

    private Color DaytimeColor;
    private Color nighttimeColor = Color.blue;


    // Start is called before the first frame update
    void Start()
    {
        theSun = transform.gameObject;
        theSunLight = theSun.GetComponent<Light>();

        //sec to min
        DayTime *= 60;
        NightTime *= 60;

        isDay = true;
        currentDayTime = DayTime;
        currentNightTime = NightTime;

        DaytimeColor = theSunLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay == true)
        {
            theSunLight.color = DaytimeColor;
            theSunLight.intensity = 1f;
            currentDayTime -= Time.deltaTime;
            if(currentDayTime < 0f)
            {
                currentNightTime = NightTime;
                isDay = false;
            }
        }
        else
        {
            theSunLight.color = nighttimeColor;
            theSunLight.intensity = 0.5f;
            currentNightTime -= Time.deltaTime;
            if (currentNightTime < 0f)
            {
                currentDayTime = DayTime;
                isDay = true;
            }
        }
    }
}
