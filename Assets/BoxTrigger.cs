using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
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
        Debug.Log("trigger event " + other.name);
	Debug.Log("Get Triggered.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision event " + collision.collider.name);
    }
}
