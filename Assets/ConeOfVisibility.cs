using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfVisibility : MonoBehaviour
{
    public bool spotedPlayer;
    private bool chase;
    private bool PlayerInCone;


    private float Intervals = 3f;
    private float counter;


    Vector3 direction;
    GameObject Player;
    Vector3 playerPos;
    private void Start()
    {
        counter = Intervals;
    }

    private void Update()
    {
        if (PlayerInCone == true)
        {
            counter -= Time.deltaTime;
            if (counter < 0f)
            {
                playerPos = Player.transform.position;
                CheckForPlayer();
                counter = Intervals;
            }
        }
        else
        {
            spotedPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = other.transform.gameObject;
            PlayerInCone = true;
            playerPos = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //only need to know ONCE if the player entered the cone
        if (other.tag == "Player")
        {
            PlayerInCone = false;
        }
    }
        private void CheckForPlayer()
    {
        //cast a ray to the player to see if anything is blocking the view
        direction = playerPos - transform.position;
        float dist = direction.magnitude;

        Debug.DrawRay(transform.position, direction, Color.red, 10f);

        // Bit shift the index of the layer (8) to get a bit mask for sight blockers
        int layerMask = 1 << 8;

        RaycastHit hit;
        // Does the ray intersect any objects in the blocker layer
        if (Physics.Raycast(transform.position, direction, out hit, dist, layerMask))
        {

            Debug.Log("NPC player is Hiding");
        }
        else
        {
            //NPC sees player
            Debug.Log("NPC sees player");


            //Is Villager
            if (transform.parent.gameObject.CompareTag("Villager"))
            {
                if (transform.parent.GetComponent<NewVillager>().notified == true)
                {
                    spotedPlayer = true;
                    transform.parent.GetComponent<NewVillager>().BurnTheWitch();
                }

                if (spotedPlayer == false)
                {
                    //if it is an NPC, set navmeshagent destination to priest.
                    transform.parent.GetComponent<NewVillager>().FoundPlayer(playerPos);
                    spotedPlayer = true;
                }

            }
            //Is Priest
            else
            {

                if (spotedPlayer == false)
                {
                    if (transform.parent.GetComponent<NewPriest>().chasePlayer == false)
                    {
                        transform.parent.GetComponent<NewPriest>().chasePlayer = true;
                    }

                    spotedPlayer = true;
                }
            }



            //if it is the priest, set navmesh agent to search path

        }
    }
}
