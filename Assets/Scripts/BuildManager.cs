using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public float interactionLenght;

    public int curCrop = 0;

    public Seeds[] seeds = new Seeds[10];


    void Awake()
    {
        instance = this;
    }

    public GameObject standardCropPrefab;

    void Start()
    {
        cropToBuild = standardCropPrefab;
    }

    private GameObject cropToBuild;

    public GameObject GetCropToBuild()
    {
        return cropToBuild;
    }

    public float InterLength()
    {
        return interactionLenght;
    }
    
}
