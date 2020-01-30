using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewPriest : MonoBehaviour
{
    private NavMeshAgent agent;

    public Vector3 PlayerPos;

    private GameObject TheVillager;
    private GameObject thePlayer;
    private GameObject[] farmCrops;
    private bool foundPlayer;

    private Vector3 Home;
    private Transform Dest;

    public bool chasePlayer = false;
    private bool Praying;
    private bool Running;
    private bool setCounter;

    public float ChaseTime = 5f;
    public float PatrolTime;
    private float counter;

    private float agentSpeedRef;

    // Start is called before the first frame update
    void Start()
    {


        Running = false;
        Praying = true;

        thePlayer = GameObject.FindWithTag("Player");
        TheVillager = GameObject.FindGameObjectWithTag("Villager");
        farmCrops = GameObject.FindGameObjectsWithTag("Crop");
        agent = GetComponent<NavMeshAgent>();
        agentSpeedRef = agent.speed;
        Home = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Praying == true)
        {
            if (setCounter == true)
            {
                setCounter = false;
            }
            agent.SetDestination(Home);
            agent.stoppingDistance = 1f;
        }
        else
        {
            if (chasePlayer == true)
            {
                if (Running == false)
                {
                    agent.speed = agentSpeedRef * 1.5f;
                    Running = true;
                }
                //
                agent.SetDestination(thePlayer.transform.position);
                return;
            }
            if (agent.remainingDistance < 3f)
            {
                if (foundPlayer == false)
                {
                    GetNewDest();
                }
                if (Running == true && agent.remainingDistance < 1f)
                {
                    counter = PatrolTime;
                    agent.speed = agentSpeedRef;
                    TheVillager.GetComponent<NewVillager>().SlowDown();
                    Running = false;
                    foundPlayer = false;
                }
            }


            if (foundPlayer == false && Running == false && chasePlayer == false)
            {
                counter -= Time.deltaTime;
                
                if (counter < 0)
                {
                    Praying = true;
                    TheVillager.GetComponent<NewVillager>().atEase(); ;
                    counter = PatrolTime;
                }

            }
        }
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
        Running = true;
        Praying = false;
        agent.speed = agentSpeedRef * 2f;
        agent.SetDestination(PlayerPos);
        foundPlayer = true;
    }

    public void VillagerSpottedPlayer()
    {
        chasePlayer = true;
    }
}
