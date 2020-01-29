using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherInfo : MonoBehaviour
{
    GameObject thePlayer;
    public int ArrayIndex;

    // Start is called before the first frame update
    void Awake()
    {
        thePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
