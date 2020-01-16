using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public float cropHealth = 30;
    public bool isTaken = false;
    public bool windUsed = false;
    public bool cropDepleted;

    private void Update()
    {
        if (cropHealth > 0)
        {
            cropDepleted = false;
        }
        else
        {
            cropDepleted = true;
        }
    }

    private void OnMouseDown()
    {
        if(isTaken == true)
        {
            windUsed = true;
        }
    }
}
