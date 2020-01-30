﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfVisibility : MonoBehaviour
{
    public bool spotedPlayer;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //only need to know ONCE if the player entered the cone
        if (other.tag == "Player")
        {

            //cast a ray to the player to see if anything is blocking the view
            Vector3 direction =  other.transform.position - transform.position;
            float dist = direction.magnitude;

            Debug.DrawRay(transform.position, direction, Color.red, 10f);

            // Bit shift the index of the layer (8) to get a bit mask for sight blockers
            int layerMask = 1 << 8;

            RaycastHit hit;
            // Does the ray intersect any objects in the blocker layer
            if (Physics.Raycast(transform.position, direction, out hit, dist, layerMask))
            {
                
                Debug.Log("NPC player is Hiding");
                spotedPlayer = false;
            }
            else
            {
                //NPC sees player
                Debug.Log("NPC sees player");


                //Is Villager
                if (transform.parent.gameObject.CompareTag("Villager"))
                {
                    if (spotedPlayer == false)
                    {
                        //if it is an NPC, set navmeshagent destination to priest.
                        transform.parent.GetComponent<NewVillager>().FoundPlayer(other.transform.position);
                        spotedPlayer = true;
                    }
                }
                //Is Priest
                else
                {

                    if (spotedPlayer == false)
                    {
                        transform.parent.GetComponent<NewPriest>().chasePlayer = true;
                        spotedPlayer = true;
                    }
                }
                

                
                //if it is the priest, set navmesh agent to search path

            }
        }
    }
}
