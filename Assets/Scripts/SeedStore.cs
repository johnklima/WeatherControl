using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedStore : MonoBehaviour
{
    public GameObject SeedStoreGui;
    private bool inStore;

    public GameObject thePlayer;
    public GameObject theCamera;

    // Start is called before the first frame update
    void Start()
    {
        SeedStoreGui.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.B) && inStore == true)
        {
            inStore = false;
            SeedStoreGui.SetActive(false);
            thePlayer.GetComponent<PlayerController>().enabled = true;
            theCamera.GetComponent<ThirdPersonCamera>().enabled = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.B) && inStore == false)
        {
            inStore = true;
            SeedStoreGui.SetActive(true);
            thePlayer.GetComponent<PlayerController>().enabled = false;
            theCamera.GetComponent<ThirdPersonCamera>().enabled = false;
            return;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (inStore == true)
        {
            inStore = false;
            SeedStoreGui.SetActive(false);
            thePlayer.GetComponent<PlayerController>().enabled = true;
            theCamera.GetComponent<ThirdPersonCamera>().enabled = true;
        }

    }
}
