using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropStageOne : MonoBehaviour
{
    public int seedplanted;

    // Start is called before the first frame update
    private void Awake()
    {
        seedplanted = GetComponentInParent<FarmFieldScript>().currentCrop;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
