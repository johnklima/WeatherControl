using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewVillager : MonoBehaviour
{
    NavMeshAgent agent;

    private GameObject[] farmCrops;
    private GameObject thePriest;


    private bool foundPlayer;
    public bool notified;

    private bool onPatrol;

    private Vector3 Home;
    private Transform Dest;

    public float HomeTime;
    public float PatrolTime;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        //Starts on true for testing purposes !!Change Later!!
        onPatrol = true;

        Home = transform.position;

        agent = GetComponent<NavMeshAgent>();
        thePriest = GameObject.FindGameObjectWithTag("Priest");
        farmCrops = GameObject.FindGameObjectsWithTag("Crop");
        foundPlayer = false;
        GetNewDest();

        counter = PatrolTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        counter -= Time.deltaTime;
        if (counter < 0 && notified == false)
        {
            
            if (onPatrol == true)
            {
                counter = PatrolTime;
                onPatrol = false;
            }
            else
            {
                counter = HomeTime;
                onPatrol = true;
            }
            
        }
        //Patrol

        if (onPatrol == true)
        {
            if (agent.remainingDistance < 5f)
            {
                if (foundPlayer == false)
                {
                    GetNewDest();
                }
            }
            else if (notified == true)
            {
                agent.stoppingDistance = 5f;
            }
            //set the priest off on a search path, with the first point being where the villager spotted the witch.
            //Priest is notified by checking distance between Villager and Priest ( is this bad to do? )
            if (Vector3.Distance(transform.position, thePriest.transform.position) < 1f && notified == false)
            {
                thePriest.GetComponent<NewPriest>().IsNotified();
                notified = true;
                foundPlayer = false;
            }


            /*set a timer, wait and send him off on a search path



            once priest is there, and does not see the witch, send the priest off on a search path
            and have the NPC follow behind the priest with a pitchfork ;)
            */
        }
        else
        {
            agent.SetDestination(Home);
            agent.stoppingDistance = 1f;
        }
        

    }

    private void GetNewDest()
    {
        if (foundPlayer == false && notified == false)
        {
            int index = Random.Range(0, farmCrops.Length);
            Dest = farmCrops[index].transform;
        }
        else
        {
                Dest = thePriest.transform;
        }
        agent.SetDestination(Dest.position);
    }

    //coneofvisibility proves true, send him off to the priest
    public void FoundPlayer(Vector3 playerPos)
    {
        //first point being where the villager spotted the witch.
        thePriest.GetComponent<NewPriest>().PlayerPos = playerPos;
        if(foundPlayer == false)
        {
            agent.speed *= 2;
        }
        foundPlayer = true;
        GetNewDest();
    }

    public void SlowDown()
    {
        agent.speed /= 2f;
    }

    
}
