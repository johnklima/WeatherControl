using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject birds;

    public Vector3 offset = new Vector3(0, 5f, -10f);

    public float startTimeBtwSpawn = 5f;
    private float timeBtwSpawn = 5f;
    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
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

    void LateUpdate()
    {
        //Spawnpoint follows player
        this.transform.position = target.TransformPoint(offset);
    }
}
