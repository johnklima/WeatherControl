using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public bool spottedPlayer = false;

    public Transform[] patrolPoints = new Transform[25];
    private int curIndex;

    // Start is called before the first frame update
    void Start()
    {
        int curIndex = Random.Range(0, 23);
        agent = GetComponent<NavMeshAgent>();
        try { agent.SetDestination(patrolPoints[curIndex].position); }
        catch
        { }


    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 10.0f && !spottedPlayer)
        {
            int curIndex = Random.Range(0, 23);
            try
            { 
                agent.SetDestination(patrolPoints[curIndex].position); 
            }
            catch
            {
                Debug.Log("No Patrol points on Villager");
            }
            
        }

        if (spottedPlayer)
        {
            int curIndex = Random.Range(24, 24);
            agent.SetDestination(patrolPoints[curIndex].position);
        }
    }
}
