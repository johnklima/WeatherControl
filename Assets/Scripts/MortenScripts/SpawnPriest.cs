using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPriest : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public float spawnCooldown = 5f;
    public float spawnDelay = 0f;

    void Update()
    {
        if (spawnDelay >= 0f)
        {
            spawnDelay -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            if(spawnDelay <= 0f)
            {
                Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
                spawnDelay = spawnCooldown;
            }
        }
    }
}
