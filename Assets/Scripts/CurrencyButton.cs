using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CurrencyButton : MonoBehaviour
{
    // Start is called before the first frame update

    public float currency = 100.0f;

    void Start()
    {

        try
        {
            readCurrency();
        }
        catch
        {
            //do nothing, or maybe write the file for the first time
            writeCurrency();
        }


        GetComponentInChildren<Text>().text = "" + currency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void writeCurrency()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText("Currency.txt", json);
    }
    public void readCurrency() 
    {
        string json = System.IO.File.ReadAllText("Currency.txt");
        JsonUtility.FromJsonOverwrite(json, this);

    }
}
