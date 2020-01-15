using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedStore : MonoBehaviour
{
    public GameObject theGM;
    public TextMeshPro SeedType;

    private int seedAmount;

    private int indexer = 1;
    private int indexersize;

    private bool playerHere;

    // Start is called before the first frame update
    void Start()
    {
        playerHere = false;

        indexersize = theGM.GetComponent<GameManager>().seedPrice.Length;

        SeedType.text = theGM.GetComponent<GameManager>().seedName[indexer] + theGM.GetComponent<GameManager>().seedPrice[indexer].ToString() + "£";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHere == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (indexer == indexersize)
                {
                    indexer = 0;
                    ChangeText();
                    return;
                }
                indexer += 1;
                ChangeText();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (indexer == 0)
                {
                    indexer = indexersize;
                    ChangeText();
                    return;
                }
                indexer -= 1;

                ChangeText();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                theGM.GetComponent<GameManager>().Currency -=
                theGM.GetComponent<GameManager>().seedPrice[indexer];

                SendCashUpdate();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHere = false;
        }
    }

    private void SendCashUpdate()
    {
        theGM.GetComponent<GameManager>().UpdateCurrency();
    }

    private void ChangeText()
    {
        SeedType.text = theGM.GetComponent<GameManager>().seedName[indexer] + theGM.GetComponent<GameManager>().seedPrice[indexer].ToString() + "£";
    }
}
