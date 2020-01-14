using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{

    public NPCAI npcAIscript = null;

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
            Debug.Log(transform.parent.name + " see's player");
            
            //follow player
            npcAIscript = transform.parent.GetComponent<NPCAI>();
            npcAIscript.followPlayer = true;


        }
    }
}
