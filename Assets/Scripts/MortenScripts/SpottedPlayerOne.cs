using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedPlayerOne : MonoBehaviour
{
    /*
    public bool didhit = false;
    private GameObject playHit;
    //private GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        //Parent = GameObject.Find("Priest");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //if the cone collides with player, chase the player
        if (other.tag == "Player")
        {
            Debug.Log(transform.parent.name + " might see player");


            // Bit shift the index of the layer (9) to get a bit mask
            int layerMask = 1 << 9;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;

            RaycastHit hit;

            GameObject thePlayer = other.gameObject;

            Vector3 direction = (thePlayer.transform.position - transform.parent.position);
            float distance = direction.magnitude;
            direction.Normalize();

            //Calculate the direction from the priest to towards the player -- John Hauge Fix 
            Vector3 dist = transform.parent.position - thePlayer.transform.position;
            float head = dist.magnitude;
            Vector3 dir = dist * head;
            dir *= -1f;
            

            // Does the ray intersect any objects excluding the player layer

            if (Physics.Raycast(transform.position, direction, out hit, distance, layerMask))          
            {
               
                Debug.Log("Did Hit other object");
                playHit = hit.transform.gameObject;
                Debug.Log(playHit);

            }
            else
            {
                             
            
                Debug.Log("Saw player");
                if (transform.parent.gameObject.tag == ("Priest"))
                {
                    transform.parent.GetComponent<Priest>().spottedPlayer = true;
                }
                if (transform.parent.gameObject.tag == ("Villager"))
                {
                    transform.parent.GetComponent<Villager>().spottedPlayer = true;
                }

            }
            Debug.Log("End");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (transform.parent.gameObject.tag == "Priest")
        {
            transform.parent.GetComponent<Priest>().spottedPlayer = false;
        }

    }
*/
}
