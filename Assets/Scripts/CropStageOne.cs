using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropStageOne : MonoBehaviour
{
    public int seedplanted;

    private Vector3 offset = new Vector3(-0.05f, 0.377f,0.0f);
    public List<GameObject> Sticks;

    public GameObject[] seedBag;

    private void Awake()
    {
        GameObject[] allSticks = GameObject.FindGameObjectsWithTag("CropStick");

        foreach (GameObject StickObj in allSticks)
        {
            if (StickObj.transform.IsChildOf(transform))
            {
                Sticks.Add(StickObj);
            }
        }
        
        seedplanted = GetComponentInParent<FarmFieldScript>().fieldData.currentCrop;

        foreach (GameObject Stick in Sticks)
        {
            Instantiate(seedBag[seedplanted],Stick.transform.position + offset,seedBag[seedplanted].transform.rotation,transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
