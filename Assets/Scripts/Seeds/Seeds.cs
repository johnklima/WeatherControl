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
    public Text SeedPrice;
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
        SeedPrice.text = "Cost : " + price + "£";
        Debug.LogError("Seedprice needs to be updated after start");
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
