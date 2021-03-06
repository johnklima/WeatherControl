﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public float cooldown = -1;
    public bool followPlayer = false;

    public Transform[] patrolPoints = new Transform[10];
    public int curIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[curIndex].position);


    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 10.0f && !followPlayer)
        {
            curIndex++;
            if (curIndex >= patrolPoints.Length)
            {
                curIndex = 0;
            }

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
