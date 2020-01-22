using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Seeds : MonoBehaviour
{

    protected Text QuantityText;
    protected Text SeedPrice;
    protected CurrencyButton currencyGui;

    public float price;
    public int quantity;



    // Start is called before the first frame update
    public void getReferences()
    {
        //grab the references permanently include in SeedReferences and stuff them here
        //so we can serialize this class without bad object references
        QuantityText = GetComponent<SeedReferences>().QuantityText;
        SeedPrice = GetComponent<SeedReferences>().SeedPrice;
        currencyGui = GetComponent<SeedReferences>().currencyGui;

    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void buy()
    {
        if (currencyGui.currency > price)
        {
            quantity++;
            QuantityText.text = "" + quantity;
            //SeedPrice.text = "Cost : " + price + "£";
            //Debug.LogError("Seedprice needs to be updated after start");
            currencyGui.currency -= price;
            currencyGui.GetComponentInChildren<Text>().text = "" + currencyGui.currency;

            writeSeed();
            currencyGui.writeCurrency();



        }




    }
    public void plantSeed()
    {
        quantity -= 1;
        writeSeed();
        readSeed();
        QuantityText.text = "" + quantity;

    }

    virtual public void writeSeed()
    { 
    
    }
    virtual public void readSeed()
    {

    }
}
