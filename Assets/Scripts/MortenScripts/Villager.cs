﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public float cooldown = -1;
    public bool followPlayer = false;

    public Transform[] patrolPoints = new Transform[24];
    private int curIndex;

    // Start is called before the first frame update
    void Start()
    {
        int curIndex = Random.Range(0, 23);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[curIndex].position);


    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 10.0f && !followPlayer)
        {
            int curIndex = Random.Range(0, 23);
            agent.SetDestination(patrolPoints[curIndex].position);
        }

        if (followPlayer)
        {
            if (agent.remainingDistance > 3.0f)
            {
                agent.SetDestination(player.position);
            }
            else if (cooldown < 0)
            {
                agent.isStopped = true;
                cooldown = Time.time;
            }
            //reset destination and timer
            if (cooldown > 0 && Time.time - cooldown > 3.0f)
            {
                cooldown = -1;
                agent.isStopped = false;
                agent.SetDestination(player.position);
            }
        }

    }
}
