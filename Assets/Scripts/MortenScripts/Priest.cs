using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Priest : MonoBehaviour
{
    NavMeshAgent agent;
    public float cooldown = -1;
    public bool spottedPlayer = false;
    private int curIndex;
    public GameObject[] patrolPoints;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        patrolPoints = GameObject.FindGameObjectsWithTag("Waypoint");
        int curIndex = Random.Range(0, patrolPoints.Length);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[curIndex].transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 10.0f && !spottedPlayer)
        {
            int curIndex = Random.Range(0, patrolPoints.Length);
            agent.SetDestination(patrolPoints[curIndex].transform.position);
        }

       if (spottedPlayer = true)
        {

           if (agent.remainingDistance > 3.0f)
            {
                agent.SetDestination(Player.transform.position);
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
                agent.SetDestination(Player.transform.position);
            }
        }
    }
}
