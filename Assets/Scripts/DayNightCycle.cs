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
    public Color nighttimeColor = Color.blue;

    private GameObject[] Torches;

    private bool lightSwitch;
    //by John Hauge

    // Start is called before the first frame update
    void Start()
    {
        Torches = GameObject.FindGameObjectsWithTag("Tourch");

        theSun = transform.gameObject;
        theSunLight = theSun.GetComponent<Light>();

        //sec to min
        DayTime *= 60;
        NightTime *= 60;

        isDay = true;
        currentDayTime = DayTime;
        currentNightTime = NightTime;

        DaytimeColor = theSunLight.color;

        lightSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay == true)
        {
            if (lightSwitch == true)
            {
                lightSwitch = false;
                foreach(GameObject i in Torches)
                {
                    i.SetActive(false);
                }
            }
            theSunLight.color = DaytimeColor;
            currentDayTime -= Time.deltaTime;
            if(currentDayTime < 0f)
            {
                currentNightTime = NightTime;
                isDay = false;
            }
        }
        else
        {
            if (lightSwitch == false)
            {
                lightSwitch = true;
                foreach (GameObject i in Torches)
                {
                    i.SetActive(true);
                }
            }
            theSunLight.color = nighttimeColor;
            currentNightTime -= Time.deltaTime;
            if (currentNightTime < 0f)
            {
                currentDayTime = DayTime;
                isDay = true;
            }
        }
    }
}
