using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed; //how fast it travels
    public GameObject impactPrefab; //impact vfx prefab.
    public List<GameObject> trails;

    private Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //cache to rb to get to component rigidbody
    }

   
    void FixedUpdate() //dont want to skip frames
    {   //if speed is different than 0, if rb is different than null / if it has been instantiated
        if(speed != 0 && rb != null)
        {
            rb.position += transform.forward * (speed * Time.deltaTime); //making it move
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(impactPrefab != null)
        {
            var impactVFX = Instantiate(impactPrefab, pos, rot) as GameObject;
            Destroy(impactVFX, 8);
        }

        if (trails.Count > 0)
        {
            for(int i = 0; i< trails.Count; i++)
            {
                trails[i].transform.parent = null;
                var ps = trails[i].GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Stop();
                    Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }

        Destroy(gameObject);

       
    }
}
