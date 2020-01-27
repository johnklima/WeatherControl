using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedPlayerOne : MonoBehaviour
{

    public Priest npcAIscript = null;
    public bool didhit = false;
    public GameObject playHit;
 

    // Start is called before the first frame update
    void Start()
    {
        npcAIscript = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the cone collides with player, chase the player
        if (other.tag == "Player")
        {
            Debug.Log(transform.parent.name + " might see player");


            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;

            RaycastHit hit;
            float distance = Vector3.Distance(transform.position, other.transform.position) - 1.0f;
            bool didhit = false;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                didhit = true;

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }

            if (didhit == true && playHit.tag == "Player")
            { //follow player
                npcAIscript = transform.parent.GetComponent<Priest>();
                npcAIscript.spottedPlayer = true;
            }


        }
    }
}
