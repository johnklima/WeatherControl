﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotsSeeds : Seeds
{
    // Start is called before the first frame update
    void Awake()
    {
        getReferences();

        price = 0.95f;
        GrowthTimer = 14.4f;

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
        GrowthTime.text = "GrowthTime :" + GrowthTimer;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void writeSeed()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText("SeedData/Carrots.txt", json);

    }
    public override void readSeed()
    {
        string json = System.IO.File.ReadAllText("SeedData/Carrots.txt");
        JsonUtility.FromJsonOverwrite(json, this);

    }
}
