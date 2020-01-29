﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewPriest : MonoBehaviour
{
    private NavMeshAgent agent;
    public bool chasePlayer = false;
    public Vector3 PlayerPos;

    private GameObject TheVillager;
    private GameObject[] farmCrops;
    private bool foundPlayer;

    private Vector3 Home;
    private Transform Dest;

    private bool Praying;
    private bool Running;

    public float PatrolTime;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        Running = false;
        Praying = true;

        TheVillager = GameObject.FindGameObjectWithTag("Villager");
        farmCrops = GameObject.FindGameObjectsWithTag("Crop");
        agent = GetComponent<NavMeshAgent>();
        Home = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Praying == true)
        {
            agent.SetDestination(Home);
            agent.stoppingDistance = 1f;
        }
        else
        {
            if (foundPlayer == false && Running == false)
            {
                counter -= Time.deltaTime;
                
                if (counter < 0)
                {
                    Praying = true;
                    TheVillager.GetComponent<NewVillager>().notified = false;
                }

            }
            {

            }
            if (agent.remainingDistance < 3f)
            {
                if (foundPlayer == false)
                {
                    GetNewDest();
                    if (Running == true)
                    {
                        agent.speed /= 2f;
                        TheVillager.GetComponent<NewVillager>().SlowDown();
                        Running = false;
                    }
                }
                else if (Vector3.Distance(transform.position, PlayerPos) < 1f)
                {
                    foundPlayer = GetComponentInChildren<ConeOfVisibility>().spotedPlayer;
                }
            }
        }


        /*if a villager enters his collision box, meaning the villager spotted the witch
        set the navmeshagent destination to a patrol path.

        when the visibility cone proves true, he sees the player, set the destination to the player

        PERIODICALLLY check if the player is no longer inside the cone, resume patrol path

        once player is back in cone, set destination to player
       */
    }

    private void GetNewDest()
    {
        if (foundPlayer == false)
        {
            int index = Random.Range(0, farmCrops.Length);
            Dest = farmCrops[index].transform;
        }
        agent.SetDestination(Dest.position);
    }

    public void IsNotified()
    {
        counter = PatrolTime;
        Running = true;
        Praying = false;
        agent.speed *= 2f;
        agent.SetDestination(PlayerPos);
        foundPlayer = true;
    }
}
