using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

            // Bit shift the index of the layer (8) to get a bit mask for sight blockers
            int layerMask = 1 << 8;



            RaycastHit hit;
            // Does the ray intersect any objects in the blocker layer
            if (Physics.Raycast(transform.position, direction, out hit, dist, layerMask))
            {
                
                Debug.Log("NPC is Hiding");
            }
            else
            {
                //NPC sees player
                Debug.Log("NPC sees player");

                //if it is an NPC, set navmeshagent destination to priest.
                //if it is the priest, set navmesh agent to search path

            }
            


        }
    }
}
