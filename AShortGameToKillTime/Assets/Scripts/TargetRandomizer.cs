using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TargetRandomizer : MonoBehaviour
{
    public GameObject redSword;
    public GameObject blueSword;
    public GameObject greenSword;

    Vector3 targetOneStateOnePosition;
    Vector3 targetTwoStateOnePosition;
    Vector3 targetThreeStateOnePosition;

    Vector3 targetOneFinalPosition;
    Vector3 targetTwoFinalPosition;
    Vector3 targetThreeFinalPosition;

    Vector3 targetOneRotation;
    Vector3 targetTwoRotation;
    Vector3 targetThreeRotation;

    int transitionState;
    float waitTime;
    void Start()
    {
        waitTime = 0;
        transitionState = 0;

        targetOneStateOnePosition = new Vector3(redSword.transform.position.x, redSword.transform.position.y + 20, redSword.transform.position.z);
        targetTwoStateOnePosition = new Vector3(blueSword.transform.position.x + 5, blueSword.transform.position.y + 20, blueSword.transform.position.z);
        targetThreeStateOnePosition = new Vector3(greenSword.transform.position.x - 5, greenSword.transform.position.y + 20, greenSword.transform.position.z);

        GameObject[] possibleLocations = GameObject.FindGameObjectsWithTag("sword_target");
        GameObject targetOne = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        targetOneFinalPosition = targetOne.transform.position;
        targetOneRotation = targetOne.transform.eulerAngles;
        GameObject.Destroy(targetOne);

        possibleLocations = GameObject.FindGameObjectsWithTag("sword_target");
        GameObject targetTwo = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        targetTwoFinalPosition = targetTwo.transform.position;
        targetTwoRotation = targetTwo.transform.eulerAngles;
        GameObject.Destroy(targetTwo);

        possibleLocations = GameObject.FindGameObjectsWithTag("sword_target");
        GameObject targetThree = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        targetThreeFinalPosition = targetThree.transform.position;
        targetThreeRotation = targetThree.transform.eulerAngles;
        GameObject.Destroy(targetThree);
    }
    //animate the scattering so it happens right in front of the player.
    // Update is called once per frame
    void Update()
    {
        switch (transitionState)
        {
            case 0:
                //Show the player the swords they'll be looking for.
                waitTime += Time.deltaTime;
                if(waitTime > 1)
                {
                    waitTime = 0;
                    transitionState += 1;
                }
                break;
            case 1:
                
                MoveSwordsTowardsTargets(targetOneStateOnePosition, targetTwoStateOnePosition, targetThreeStateOnePosition, 5);
                waitTime += Time.deltaTime;
                if(waitTime > 3)
                {
                    waitTime = 0;
                    transitionState += 1;
                }
                break;
            case 2:
                redSword.transform.position = targetOneFinalPosition;
                blueSword.transform.position = targetTwoFinalPosition;
                greenSword.transform.position = targetThreeFinalPosition;
                redSword.transform.eulerAngles = targetOneRotation;
                blueSword.transform.eulerAngles = targetTwoRotation;
                greenSword.transform.eulerAngles = targetThreeRotation;
                GameObject.Destroy(this);
                break;
            default:
                break;
        }
        
    }

    //returns true when swords are all on their targets.
    bool MoveSwordsTowardsTargets(Vector3 redTarget, Vector3 blueTarget, Vector3 greenTarget, int speed)
    {
        Vector3 redBetween = Vector3.MoveTowards(redSword.transform.position, redTarget, Time.deltaTime * speed);
        Vector3 blueBetween = Vector3.MoveTowards(blueSword.transform.position, blueTarget, Time.deltaTime * speed);
        Vector3 greenBetween = Vector3.MoveTowards(greenSword.transform.position, greenTarget, Time.deltaTime * speed);
        if(redSword.transform.position == redBetween && blueSword.transform.position == blueBetween && greenSword.transform.position == greenBetween)
        {
            return true;
        } else
        {
            redSword.transform.position = redBetween;
            blueSword.transform.position = blueBetween;
            greenSword.transform.position = greenBetween;
        }

        return false;
    }
}
