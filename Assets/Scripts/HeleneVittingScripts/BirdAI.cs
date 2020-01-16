using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public GameObject spawnPoint;

    public int speed = 5;
    private int attemptsToFindTarget = 0;
    //cropLoss per second
    public float cropLoss = 1f;

    private bool foundTarget = false;

    private GameObject[] cropTargets;
    private GameObject[] crops;
    private GameObject crop;

    private int target;

    Crop cropScript;

    private void Start()
    {
        spawnPoint = GameObject.Find("BirdSpawnPoint");
    }

    public void Update()
    {

        if (foundTarget == false)
        {
            //Returns an array of all the crop targets
            cropTargets = GameObject.FindGameObjectsWithTag("CropTarget");
            //Chooses a random target from the array
            target = Random.Range(0, cropTargets.Length);

            //Return an array of all crops
            crops = GameObject.FindGameObjectsWithTag("Crop");
            //Chooses the crop the birds has targeted
            crop = crops[target];
            cropScript = crop.GetComponent<Crop>();

            if (cropScript.isTaken == true || cropScript.cropDepleted == true)
            {
                target = Random.Range(0, cropTargets.Length);
                attemptsToFindTarget++;
            }

            if (cropScript.isTaken == false && cropScript.windUsed == false && cropScript.cropDepleted == false)
            {
                foundTarget = true;
                cropScript.isTaken = true;
            }
        }

        //Moves towards target
        if (cropScript.cropDepleted == false && foundTarget == true && cropScript.windUsed == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, cropTargets[target].transform.position, speed * Time.deltaTime);
        }

        if (transform.position == cropTargets[target].transform.position)
        {
            //Depletes crop health
            cropScript.cropHealth -= Time.deltaTime * cropLoss;
        }

        //Birds fly away when crop is depleted
        if (cropScript.cropDepleted == true && foundTarget == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint.transform.position, speed * Time.deltaTime);

            if (transform.position == spawnPoint.transform.position)
            {
                cropScript.isTaken = false;
                Destroy(gameObject);
            }
        }

        //Birds get destroyed when wind is used
        if (cropScript.windUsed == true)
        {
            if (transform.position == cropTargets[target].transform.position)
            {
                cropScript.isTaken = false;
                cropScript.windUsed = false;
                Destroy(gameObject);
            }
        }

        if (attemptsToFindTarget >= 20)
        {
            Destroy(gameObject);
        }
    }
}