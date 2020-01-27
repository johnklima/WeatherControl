using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVillager : MonoBehaviour
{

    public GameObject[] Spawnpoints;
    public GameObject Prefab;


    // How often does a villager spawn?
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
            Instantiate(Prefab, spawnPos.transform.position, spawnPos.transform.rotation);
            counter = spawnTimerMinutes;
        }

    }
}
