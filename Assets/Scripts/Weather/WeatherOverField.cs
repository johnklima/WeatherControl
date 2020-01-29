using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherOverField : MonoBehaviour
{

    public GameObject[] WeatherParticleFX;
    

    private GameObject CurrentWeather;



    // Start is called before the first frame update
    void awake()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWeather(GameObject Weathertype)
    {
        int listNR = Weathertype.GetComponent<WeatherInfo>().ArrayIndex;
        GameObject weatherSpawn = Instantiate(WeatherParticleFX[listNR], transform);
        CurrentWeather = weatherSpawn;
    }

}
