using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedStore : MonoBehaviour
{
    public GameObject SeedStoreGui;
    private bool inStore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        PlayerHere();
    }

    private void PlayerHere()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            inStore = true;
            SeedStoreGui.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inStore = false;
            SeedStoreGui.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SeedStoreGui.SetActive(false);
    }
}
