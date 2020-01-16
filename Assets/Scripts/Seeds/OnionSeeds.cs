using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionSeeds : Seeds
{
    // Start is called before the first frame update
    void Start()
    {
        price = 0.99f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void writeSeed()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText("Onions.txt", json);

    }
    public override void readSeed()
    {
        string json = System.IO.File.ReadAllText("Onions.txt");
        JsonUtility.FromJsonOverwrite(json, this);

    }
}
