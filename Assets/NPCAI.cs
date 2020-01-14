using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public float cooldown = -1;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > 3.0f)
        {
            agent.SetDestination(player.position);
        }            
        else if(cooldown < 0)
        {
            agent.isStopped = true;
            cooldown = Time.time;
        }
        //reset destination and timer
        if(cooldown > 0 && Time.time - cooldown > 3.0f)
        {
            cooldown = -1;
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }


    }
}
