using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{

    /* <JPK> disable all
    NavMeshAgent agent;
    private GameObject player;
    public GameObject ChurchWaypoint;
    public bool spottedPlayer = false;
    public List<Transform> patrolPoints;
    private int curIndex;
    public GameObject[] exits;
    private GameObject exit;
    private bool exiting;
    private bool running;
    public float PatrolTimerMin;
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        exiting = false;
        PatrolTimerMin *= 60f;
        ChurchWaypoint = GameObject.Find("ChurchSpawner");
        Debug.Log(ChurchWaypoint);
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
        PatrolTimerMin -= Time.deltaTime;

        if (agent.remainingDistance < 3f && spottedPlayer == false && exiting == false)
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
        if (spottedPlayer == true)
        {
            agent.SetDestination(ChurchWaypoint.transform.position);
            if(running == false)
            {
                agent.speed *= 2;
                running = true;
            }
            
        }

        if (PatrolTimerMin < 0f && spottedPlayer == false)
        {
            if (exiting == false)
            {
                exit = exits[Random.Range(0, exits.Length)];
                exiting = true;
            }
            else
            {
                float Dist = Vector3.Distance(exit.transform.position, transform.position);

                agent.SetDestination(exit.transform.position);

                if (Dist < 2)
                {
                    Destroy(transform.gameObject);
                }
            }
            
            

        }


    }
    */
}
