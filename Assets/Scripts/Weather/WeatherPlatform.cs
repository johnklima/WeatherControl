using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherPlatform : MonoBehaviour
{

    private GameObject theParent;

    public GameObject[] WeatherEffects;

    private GameObject SelectedWeather;
    public int Index;

    public bool playerHere;
    private bool spawnedWeather;



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (playerHere == true)
        {
            Debug.Log(" I am Awakened!");
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Index += 1;
                if (Index == 4)
                {
                    Index = 0;
                }
                Destroy(SelectedWeather);
                GameObject SpawnedWeather = Instantiate(WeatherEffects[Index], transform);
                SelectedWeather = SpawnedWeather;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Index -= 1;
                if (Index == -1)
                {
                    Index = 3;
                }
                Destroy(SelectedWeather);
                GameObject SpawnedWeather = Instantiate(WeatherEffects[Index], transform);
                SelectedWeather = SpawnedWeather;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                SendWeather();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player is here");
            playerHere = true;
            GameObject SpawnedWeather = Instantiate(WeatherEffects[Index],transform);
            SelectedWeather = SpawnedWeather;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(SelectedWeather);
        playerHere = false;
    }

    private void SendWeather()
    {
        spawnedWeather = true;
        GetComponentInParent<FarmFieldScript>().Weather(SelectedWeather);
    }
}
