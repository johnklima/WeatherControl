using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public float interactionLenght;

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
