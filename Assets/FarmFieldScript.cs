using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmFieldScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentCrop = 1;
    public string plantedSeed;

    void awake()
    {
        plantedSeed = BuildManager.instance.seeds[currentCrop].name.ToString();
        Debug.Log(plantedSeed + "has been planted");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
