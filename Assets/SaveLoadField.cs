
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveLoadField : MonoBehaviour
{
    
    public bool isPlanted = false;
    public int currentCrop = -1;
    public int index;

    public bool stage1bool;
    public bool stage2bool;
    public bool stage3bool;

    private void Awake()
    {
        try
        {
            readData();
        }
        catch
        {
            //do nothing, or maybe write the file for the first time
            writeData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void writeData()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText("SeedData/Field" + index +".txt", json);

    }
    public  void readData()
    {
        string json = System.IO.File.ReadAllText("SeedData/Field" + index + ".txt");
        JsonUtility.FromJsonOverwrite(json, this);

    }
}
