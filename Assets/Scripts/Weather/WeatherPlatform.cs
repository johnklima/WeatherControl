using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherPlatform : MonoBehaviour
{
    public GameObject Sun;
    public GameObject Rain;
    public GameObject Lightning;
    public GameObject Snow;

    private BoxCollider thisCollider;

    private List<GameObject> WeatherEffects;

    private GameObject SelectedWeather;
    public int Index;

    // Start is called before the first frame update
    void awake()
    {
        thisCollider = GetComponent<BoxCollider>();

        WeatherEffects.Add(Sun);
        WeatherEffects.Add(Rain);
        WeatherEffects.Add(Lightning);
        WeatherEffects.Add(Snow);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {

        Debug.Log("Mouse is Over");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Pressed Q");
            Index += 1;
            if (Index == -1)
            {
                Index = 4;
            }
            Destroy(SelectedWeather.gameObject);
            SelectedWeather = Instantiate(WeatherEffects[Index], transform);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            Index -= 1;
            if (Index == 5)
            {
                Index = 1;
            }
            Destroy(SelectedWeather.gameObject);
            SelectedWeather = Instantiate(WeatherEffects[Index], transform);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed Mousebutton");
        GetComponentInParent<FarmFieldScript>().Weather(SelectedWeather.name);
    }

}
