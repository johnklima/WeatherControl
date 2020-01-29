using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FarmFieldScript : MonoBehaviour
{
    // Start is called before the first frame update

    //the seed that is planted

    [Serializable]
    public class FarmFieldData
    {
        public int currentCrop = 1;
        public float growthTime;

         //Stage 2 time trigger
        public float stage2;


        //StageTriggers
        public bool stage1bool;
        public bool stage2bool;
        public bool stage3bool;

        public bool isplanted;
        public bool isFinished;

        public int plotIndex = -1;


    }

    //Weather Over Field
    public String CurrentWeather;


    public FarmFieldData fieldData;   

    public GameObject TheCropField;
    //List of Prefab Growth Stages
    public GameObject[] StageTwoPrefab;
    public GameObject[] StageThreePrefab;
    //TimeLeft Counter

    public TextMeshPro Counter1;
    public TextMeshPro Counter2;

    //Crop Stage 1
    public GameObject stageOnePrefab;
    private Vector3 StageOneOffset = new Vector3(0f,0.3f,0f);

    private GameObject currentStage;

    bool bootme = true;

    private void Start()
    {

        fieldData.stage1bool = false;
        fieldData.stage2bool = false;
        fieldData.stage3bool = false;

        fieldData.isFinished = false;



        try
        {
            readData();
        }
        catch
        {
            //do nothing, or maybe write the file for the first time
           
        }


    }


    public void writeData()
    {
        string json = JsonUtility.ToJson(fieldData);
        System.IO.File.WriteAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt", json);

    }
    public void readData()
    {
        string json = System.IO.File.ReadAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt");
        JsonUtility.FromJsonOverwrite(json, fieldData);

    }


    void awake()
    {
        fieldData.isplanted = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (bootme)
        {  //get the plants where they should be
            bootme = false;
            if (fieldData.stage1bool)
            {
                currentStage = Instantiate(stageOnePrefab, transform.position + StageOneOffset, transform.rotation, transform);
                currentStage.GetComponent<CropStageOne>().seedplanted = fieldData.currentCrop;
            }
            if (fieldData.stage2bool)
            {

                currentStage = Instantiate(StageTwoPrefab[fieldData.currentCrop], transform.position, transform.rotation, transform);
            }
            if (fieldData.stage3bool)
            {
                currentStage = Instantiate(StageThreePrefab[fieldData.currentCrop], transform.position, transform.rotation, transform);
            }
            if (fieldData.isFinished)
            { 
                currentStage = Instantiate(StageThreePrefab[fieldData.currentCrop], transform.position, transform.rotation, transform); 
            }

        }
        
        
        if (fieldData.isplanted == true && fieldData.isFinished == false)
        {
            fieldData.growthTime -= Time.deltaTime;
            Counter1.text = fieldData.growthTime.ToString("N0");
            Counter2.text = fieldData.growthTime.ToString("N0");

            string json = JsonUtility.ToJson(fieldData);
            System.IO.File.WriteAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt", json);

            if (fieldData.growthTime > fieldData.stage2)
            {
                if (fieldData.stage1bool == false)
                {
                    fieldData.stage1bool = true;
                    Debug.Log("Stage1");
                    currentStage = Instantiate(stageOnePrefab, transform.position + StageOneOffset,transform.rotation,transform);
                    currentStage.GetComponent<CropStageOne>().seedplanted = fieldData.currentCrop;
                    
                    string json2 = JsonUtility.ToJson(fieldData);
                    System.IO.File.WriteAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt", json2);
                    return;
                }
            }
            if (fieldData.growthTime < fieldData.stage2)
            {
                if (fieldData.stage2bool == false)
                {
                    Destroy(currentStage);
                    
                    Debug.Log("stage2");
                    fieldData.stage1bool = false;
                    fieldData.stage2bool = true;
                    currentStage = Instantiate(StageTwoPrefab[fieldData.currentCrop], transform.position, transform.rotation, transform);
                    string json3 = JsonUtility.ToJson(fieldData);
                    System.IO.File.WriteAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt", json3);
                    return;
                }
            }
            if (fieldData.growthTime < 0f)
            {
                if (fieldData.stage3bool == false)
                {
                    Destroy(currentStage);
                    currentStage = Instantiate(StageThreePrefab[fieldData.currentCrop], transform.position, transform.rotation, transform);
                    Debug.Log("stage3 Finished Crop");
                    fieldData.stage2bool = false;
                    fieldData.stage3bool = true;
                    fieldData.isFinished = true;
                    string json4 = JsonUtility.ToJson(fieldData);
                    System.IO.File.WriteAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt", json4);
                }
            }
        }

    }

    public void Planted(bool PlantedCrop)
    {

        fieldData.isplanted = PlantedCrop;
        fieldData.growthTime = GameObject.Find("SeedList").GetComponent<SeedList>().seeds[fieldData.currentCrop].growthTime;
        //min to sec converter
        fieldData.growthTime *= 60f;

        fieldData.stage2 = fieldData.growthTime /  2;


        string json = JsonUtility.ToJson(fieldData);
        System.IO.File.WriteAllText("SeedData/FieldPlanted" + fieldData.plotIndex + ".txt", json);
    }

    // Getting Weather Information
    public void Weather(string WeatherType)
    {
        CurrentWeather = WeatherType;
        GetComponentInChildren<WeatherOverField>().SpawnWeather(WeatherType);

    }

}
