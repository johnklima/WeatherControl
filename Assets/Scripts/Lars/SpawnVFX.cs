using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVFX : MonoBehaviour
{
    public GameObject vfx; //our vfx prefab to spawn
    public Transform startPoint; //where it will spawn, a.      //you create a empty gameobject, startPoint, make it a child of empty gameobject, endPoint.
    public Transform endPoint; //where it will travel to, b     //Place this script onto parent gameobject, place prefabs in slots, make this parent gameobject into prefab.
  
    void Start()
    {
        var startPos = startPoint.position; //the position of the start point
        GameObject objVFX = Instantiate(vfx, startPos, Quaternion.identity) as GameObject; //instantiating the vfx prefab, at our startPoint

        var endPos = endPoint.position; //the location of the endPoint

        RotateTo(objVFX, endPos); //rotates it to move towards the endPos position
    }

    void RotateTo(GameObject obj, Vector3 destination) //declaring a function
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
