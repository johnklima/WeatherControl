using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedPlayerOne : MonoBehaviour
{

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


            // Bit shift the index of the layer (8) to get a bit mask
            

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;

            RaycastHit hit;

            GameObject thePlayer = other.gameObject;


            //Calculate the direction from the priest to towards the player -- John Hauge Fix 
            Vector3 dist = transform.parent.position - thePlayer.transform.position;
            float head = dist.magnitude;
            Vector3 dir = dist * head;
            dir *= -1f;


            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.parent.position, dir,out hit))
            {
                Debug.DrawRay(transform.parent.position, dir * hit.distance, Color.yellow, 10f);
                Debug.Log("Did Hit");
                playHit = hit.transform.gameObject;
                Debug.Log(playHit);

            }
            else
            {
                Debug.DrawRay(transform.parent.position, dir, Color.white,10f);
                Debug.Log("Did not Hit");
            }

            if (playHit.tag == "Player")
            { //follow player
                Debug.Log("hit Player");
                if (transform.parent.gameObject.tag == ("Priest"))
                {
                    transform.parent.GetComponent<Priest>().spottedPlayer = true;
                }
                else
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
}
