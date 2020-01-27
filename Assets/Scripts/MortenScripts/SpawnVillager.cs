using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVillager : MonoBehaviour
{

    public Transform Spawnpoint;
    public GameObject Prefab;
    GameObject[] villagerList;

    // Update is called once per frame
    void Update()
    {
        villagerList = GameObject.FindGameObjectsWithTag("Villager");
        if(villagerList.Length <= 2)
        {
            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        }

    }
}
