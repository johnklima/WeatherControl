using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Seeds : MonoBehaviour
{

    public float price;
    public int quantity;
    public Text QuantityText;
    public CurrencyButton currencyGui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buy()
    {
        quantity++;
        QuantityText.text = "" + quantity;
        currencyGui.currency -= price;
        currencyGui.GetComponentInChildren<Text>().text = "" + currencyGui.currency;

        writeSeed();
        currencyGui.writeCurrency();


    }
    virtual public void writeSeed()
    { 
    
    }
    virtual public void readSeed()
    {

    }
}
