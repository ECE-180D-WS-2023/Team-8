/// Spawner
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] points;
    public float beat = (60f / 125f) * 2f;
    private float timer;

    Vector3 startPosition = new Vector3(0, 1.6f, 50f);
    Vector3 startPositionLeft = new Vector3(-0.8f, 1.6f, 50f);
    Vector3 startPositionRight = new Vector3(0.8f, 1.6f, 50f);
    Vector3 finalPosition = new Vector3(0, 1.6f, -1);
    Vector3 finalPositionLeft = new Vector3(-0.8f, 1.6f, -1f);
    Vector3 finalPositionRight = new Vector3(0.8f, 1.6f, -1f);
    float actualspeed = (60f / 125f) * 2;
    float speed = 0.096f;
    // was 0.2f

    public List<GameObject> targets = new List<GameObject>();

    public float timeSinceLastSpawn = 0;
    public float timeBetweenSpawns = 0.96f;

    void Start()
    {
        //GameObject target = Instantiate(prefab, startPositionLeft, Quaternion.identity);
        //targets.Add(target);
        //GameObject target2 = Instantiate(prefab, startPosition, Quaternion.identity);
        //targets.Add(target2);

    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            if (targets.Count % 2 == 0)
            {
                GameObject target = Instantiate(prefab, startPositionLeft, Quaternion.Euler(0, 0, 90));
                targets.Add(target);
                timeSinceLastSpawn = 0;
            } 
            else if (targets.Count % 2 == 1)
            {
                GameObject target = Instantiate(prefab, startPositionLeft, Quaternion.Euler(0, 0, 270));
                targets.Add(target);
                timeSinceLastSpawn = 0;
            }
            
        }
        SpawnObject();

        // Destroy each target that has passed the final z position
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (targets[i].transform.position.z <= finalPosition.z)
            {
                GameObject target = targets[i];
                targets.RemoveAt(i);
                DestroyImmediate(target);
            }
            else
            {
                break;
            }
        }
        //foreach (GameObject target in targets)
        //{
            //if(target.transform.position.z <= finalPosition.z)
            //{
                //targets.Remove(target);
                //DestroyImmediate(target);
            //}
        //}

    }

    void SpawnObject()
    {
        float elapsedTime = Time.time;
        //List<GameObject> targetsToDelete = new List<GameObject>();
        for (int i = 0; i < targets.Count; i++) // add time condition
        {
            if (targets[i] != null)
            {
                GameObject target = targets[i];
                Vector3 currentPosition;
                if (i % 2 == 0)
                {
                    currentPosition = startPositionRight + (finalPositionRight - startPositionRight) * ((elapsedTime - (i * timeBetweenSpawns)) * speed);
                    target.transform.position = currentPosition;
                    // if currentPosition == finalPositionRight
                    //if (currentPosition.z <= finalPositionRight.z)
                    //{
                    //Debug.Log("Destroying right target");
                    //targets.RemoveAt(i);
                    //DestroyImmediate(target);
                    //Debug.Log("Adding right target to deletion list");
                    //targetsToDelete.Add(target);
                    //break;
                    //}
                }
                else if (i % 2 == 1)
                {
                    currentPosition = startPositionLeft + (finalPositionLeft - startPositionLeft) * ((elapsedTime - (i * timeBetweenSpawns)) * speed);
                    target.transform.position = currentPosition;
                    // if currentPosition == finalPositionLeft
                    //if (currentPosition.z <= finalPositionLeft.z)
                    //{
                    //Debug.Log("Destroying left target");
                    //targets.RemoveAt(i);
                    //DestroyImmediate(target);
                    //Debug.Log("Adding left target to deletion list");
                    //targetsToDelete.Add(target);
                    //break;
                    //}
                }
            }
        }

        // remove and destroy targets in the deletion list
        //foreach (GameObject target in targetsToDelete)
        //{
            //targets.Remove(target);
            //DestroyImmediate(target);
        //}
    }
}

