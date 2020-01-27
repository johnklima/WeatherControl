using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedStore : MonoBehaviour
{
    public GameObject SeedStoreGui;

   
    public GameObject thePlayer;
    public GameObject theCamera;

    // Start is called before the first frame update


    private void Awake()
    {
        SeedStoreGui.SetActive(true);
    }
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
        if (other.tag == "Player")
            PlayerHere();
    }

    private void PlayerHere()
    {
        Debug.Log(" Player here " + " active " + SeedStoreGui.activeInHierarchy);
 
        //<JPK>
        if (!SeedStoreGui.activeInHierarchy && Input.GetKeyDown(KeyCode.B) )        
        {

            Debug.Log(" B press One");
            SeedStoreGui.SetActive(true);
            thePlayer.GetComponent<PlayerController>().enabled = false;
            theCamera.GetComponent<ThirdPersonCamera>().enabled = false;
            return;
        }

        if (SeedStoreGui.activeInHierarchy && Input.GetKeyDown(KeyCode.B) )
        {
            Debug.Log(" B press Two");
            SeedStoreGui.SetActive(false);
            thePlayer.GetComponent<PlayerController>().enabled = true;
            theCamera.GetComponent<ThirdPersonCamera>().enabled = true;
            return;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //<JPK> this might be redundant
          
            SeedStoreGui.SetActive(false);
            thePlayer.GetComponent<PlayerController>().enabled = true;
            theCamera.GetComponent<ThirdPersonCamera>().enabled = true;
       

    }
}
