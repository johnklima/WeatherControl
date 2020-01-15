using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject theSun;
    public float DayCycle;
    public float weekcycle;

    public TextMeshProUGUI CurrencyUI;
    public float Currency;

    

    public float[] seedPrice;
    public string[] seedName;

    // Start is called before the first frame update
    void Start()
    {
        DayCycle = theSun.GetComponent<DayNightCycle>().DayTime + theSun.GetComponent<DayNightCycle>().NightTime;

        weekcycle = DayCycle * 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCurrency()
    {
        CurrencyUI.text = "Currency = " + Currency.ToString();
    }
}
