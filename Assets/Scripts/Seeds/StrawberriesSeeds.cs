﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberriesSeeds : Seeds
{
    // Start is called before the first frame update
    void Awake()
    {
        getReferences();
        price = 0.5f;

        try
        {
            readSeed();
        }
        catch
        {
            //do nothing, or maybe write the file for the first time
            writeSeed();
        }
        QuantityText.text = "" + quantity;
        SeedPrice.text = "Cost : " + this.price + "£";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void writeSeed()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText("SeedData/Strawberries.txt", json);

    }
    public override void readSeed()
    {
        string json = System.IO.File.ReadAllText("SeedData/Strawberries.txt");
        JsonUtility.FromJsonOverwrite(json, this);

    }
}
