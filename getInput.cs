using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class getInput : MonoBehaviour
{
    //public Spawner myspawner;
    public int playerScore = 0;

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Object entered the trigger");
        // Get object orientation
        //transform.rotation = other.transform.Quanternion.identity();
        Quaternion objectRotation;
        Vector3 objectPosition;
        other.GetPositionAndRotation(out Vector3 objectPosition, out Quaternion objectRotation);
    }

    void OnTriggerStay (Collider other)
    {
        Debug.Log("Object is within trigger");

        // Get user input
        Debug.Log(playerInput.currentActionMap);
        string swipeDirection = "left"; // not always true

        // Check if user input matches current object objectRotation
        // 90 ==> swipe right, 270 ==> swipe left
        // 180 ==> up, 0 ==> down
        // if they match, increment playerScore
        if (objectRotation == Quanternion.Euler(0,0,270)) {
          if (swipeDirection == "left") {
            playerScore++;
          }
        } else if (objectRotation == Quanternion.Euler(0,0,90)) {
          if (swipeDirection == "right") {
            playerScore++;
          }
        } else if (objectRotation == Quanternion.Euler(0,0,180)) {
          if (swipeDirection == "up") {
            playerScore++;
          }
        } else if (objectRotation == Quanternion.Euler(0,0,0)) {
          if (swipeDirection == "down") {
            playerScore++;
          }
        }

        // Update the player score display
        Debug.Log("Player Score: ");
        Debug.Log(playerScore);
    }

    void OnTriggerExit (Collider other)
    {
        Debug.Log("Object has exited the trigger box region.");
        if (other.CompareTag("targetPrefab"))
        {
            Destroy(other.gameObject);
            //targets.RemoveAt(targets.size() - 1);
        }
    }
}
