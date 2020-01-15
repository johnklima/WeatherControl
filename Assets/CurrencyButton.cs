using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CurrencyButton : MonoBehaviour
{
    // Start is called before the first frame update

    public float currency = 100.0f;

    void Start()
    {
        GetComponentInChildren<Text>().text = "" + currency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
