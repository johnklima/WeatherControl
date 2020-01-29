using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherOverField : MonoBehaviour
{
    public GameObject Sun;
    public GameObject Rain;
    public GameObject Lightning;
    public GameObject Snow;

    private List<GameObject> WeatherTypes;

    private GameObject CurrentWeather;

    

    // Start is called before the first frame update
    void awake()
    {
        WeatherTypes.Add(Sun);
        WeatherTypes.Add(Rain);
        WeatherTypes.Add(Lightning);
        WeatherTypes.Add(Snow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWeather(string Weathertype)
    {
        foreach (GameObject Weather in WeatherTypes)
        {
            if (Weather.name == Weathertype)
            {
                Destroy(CurrentWeather);
                CurrentWeather = Instantiate(Weather, transform);
            }
        }
    }

}
