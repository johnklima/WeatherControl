using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVillager : MonoBehaviour
{
    /* <JPK> disable all
    public GameObject[] Spawnpoints;
    public GameObject Prefab;


    // How often does a villager spawn?
    public float PatrolTime = 2;
    public float spawnTimerMinutes = 2;
    private float counter;

    private void Start()
    {
        spawnTimerMinutes *= 60;
        counter = spawnTimerMinutes;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if (counter < 0)
        {
            GameObject spawnPos = Spawnpoints[Random.Range(0, Spawnpoints.Length)];
            GameObject spawnedVillager = Instantiate(Prefab, spawnPos.transform.position, spawnPos.transform.rotation);
            spawnedVillager.GetComponent<Villager>().exits = Spawnpoints;
            spawnedVillager.GetComponent<Villager>().PatrolTimerMin = PatrolTime;
            counter = spawnTimerMinutes;
        }

    }
    */
}
