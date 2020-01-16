using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject birds;

    public float startTimeBtwSpawn = 5f;
    private float timeBtwSpawn = 5f;

    private void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(birds, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
