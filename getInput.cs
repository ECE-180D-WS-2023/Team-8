using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class getInput : MonoBehaviour
{
    //public Spawner myspawner;
    public int playerScore = 0;
    private Transform objectTransform;
    Quaternion objectRotation;
    Vector3 objectPosition;
    string swipeDirection = "none";

    void OnTriggerEnter (Collider other)
    {
        //Debug.Log("Object entered the trigger\n");
        //Debug.Log("Score: " + playerScore);

        // Get object orientation
        //transform.rotation = other.transform.Quanternion.identity();

        //objectTransform = other.GetComponent<Transform>();    // this gets the prefabs default transform
        objectTransform = other.transform;
        //objectTransform.GetPositionAndRotation(out objectPosition, out objectRotation);
        // objectRotation = objectTransform.localRotation;  // this gets the prefabs default rotation
        objectRotation = objectTransform.rotation;
        objectPosition = objectTransform.position;
    }

    void OnTriggerStay (Collider other)
    {
        //Debug.Log("Object is within trigger");

        // Get user input
        //Debug.Log(InputReader.currentActionMap);
        //string swipeDirection = "left"; // not always true
        // string swipeDirection = Input.GetKey();
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("You swiped left!");
            swipeDirection = "left";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("You swiped right!");
            swipeDirection = "right";
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("You swiped up!");
            swipeDirection = "up";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("You swiped down!");
            swipeDirection = "down";
        }

        // Update the player score display
        //Debug.Log("Player Score: " + playerScore);
    }

    void OnTriggerExit (Collider other)
    {
        //Debug.Log("Object has exited the trigger box region.");
        if (other.CompareTag("targetPrefab"))
        {
            Destroy(other.gameObject);
            //targets.RemoveAt(targets.size() - 1);
        }

        // Check if user input matches current object objectRotation
        // 90 ==> swipe right, 270 ==> swipe left
        // 180 ==> up, 0 ==> down
        // if they match, increment playerScore
        if (objectRotation == Quaternion.Euler(0, 0, 270))
        {
            //Debug.Log("Target rotation: left");
            if (swipeDirection == "left")
            {
                playerScore++;
            }
        }
        else if (objectRotation == Quaternion.Euler(0, 0, 90))
        {
            //Debug.Log("Target rotation: right");
            if (swipeDirection == "right")
            {
                playerScore++;
            }
        }
        else if (objectRotation == Quaternion.Euler(0, 0, 180))
        {
            //Debug.Log("Target rotation: up");
            if (swipeDirection == "up")
            {
                playerScore++;
            }
        }
        else if (objectRotation == Quaternion.Euler(0, 0, 0))
        {
            //Debug.Log("Target rotation: down");
            if (swipeDirection == "down")
            {
                playerScore++;
            }
        }

        // Reset the swipeDirection field
        swipeDirection = "none";

        // Print the current score
        Debug.Log("Player Score: " + playerScore);
    }
}
