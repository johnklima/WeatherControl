using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmFieldScript : MonoBehaviour
{
    // Start is called before the first frame update

        //the seed that is planted

    public int currentCrop = 1;
    public float growthTime;
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

    public bool isplanted;
    private bool isFinished;

    //StageTriggers
    private bool stage1bool;
    private bool stage2bool;
    private bool stage3bool;

    //Stage 2 time trigger
    public float stage2;

    private void Start()
    {
        stage1bool = false;
        stage2bool = false;
        stage3bool = false;

        isFinished = false;
    }

    void awake()
    {
        isplanted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isplanted == true && isFinished == false)
        {
            growthTime -= Time.deltaTime;
            Counter1.text = growthTime.ToString("N0");
            Counter2.text = growthTime.ToString("N0");

            if (growthTime > stage2)
            {
                if (stage1bool == false)
                {
                    stage1bool = true;
                    Debug.Log("Stage1");
                    currentStage = Instantiate(stageOnePrefab, transform.position + StageOneOffset,transform.rotation,transform);
                    currentStage.GetComponent<CropStageOne>().seedplanted = currentCrop;
                    return;
                }
            }
            if (growthTime < stage2)
            {
                if (stage2bool == false)
                {
                    Destroy(currentStage);
                    
                    Debug.Log("stage2");
                    stage1bool = false;
                    stage2bool = true;
                    currentStage = Instantiate(StageTwoPrefab[currentCrop], transform.position, transform.rotation, transform);
                    return;
                }
            }
            if (growthTime < 0f)
            {
                if (stage3bool == false)
                {
                    Destroy(currentStage);
                    currentStage = Instantiate(StageThreePrefab[currentCrop], transform.position, transform.rotation, transform);
                    Debug.Log("stage3 Finished Crop");
                    stage2bool = false;
                    stage3bool = true;
                    isFinished = true;
                }
            }
        }

    }

    public void Planted(bool PlantedCrop)
    {

        isplanted = PlantedCrop;
        growthTime = GameObject.Find("SeedList").GetComponent<SeedList>().seeds[currentCrop].growthTime;
        //min to sec converter
        growthTime *= 60f;

        stage2 = growthTime /  2;
    }
}
