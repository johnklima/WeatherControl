using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject player;
    public Transform ChurchWaypoint;
    public bool spottedPlayer = false;
    public List<Transform> patrolPoints;
    private int curIndex;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] patrolobj = GameObject.FindGameObjectsWithTag("Crop");
        foreach (GameObject i in patrolobj)
        {
            patrolPoints.Add(i.transform);
        }
        player = GameObject.FindGameObjectWithTag("Player");
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
            int curIndex = Random.Range(0, patrolPoints.Count);
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
            agent.SetDestination(ChurchWaypoint.position);
        }
    }
}
