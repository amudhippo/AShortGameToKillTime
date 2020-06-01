using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TargetRandomizer : MonoBehaviour
{
    public GameObject redSword;
    public GameObject blueSword;
    public GameObject greenSword;
    void Start()
    {
        GameObject[] possibleLocations = GameObject.FindGameObjectsWithTag("sword_target");
        GameObject targetOne = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        redSword.transform.position = targetOne.transform.position;
        redSword.transform.eulerAngles = targetOne.transform.eulerAngles;
        GameObject.Destroy(targetOne);
        possibleLocations = GameObject.FindGameObjectsWithTag("sword_target");
        GameObject targetTwo = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        blueSword.transform.position = targetTwo.transform.position;
        blueSword.transform.eulerAngles = targetTwo.transform.eulerAngles;
        GameObject.Destroy(targetTwo);
        possibleLocations = GameObject.FindGameObjectsWithTag("sword_target");
        GameObject targetThree = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        greenSword.transform.position = targetThree.transform.position;
        greenSword.transform.eulerAngles = targetThree.transform.eulerAngles;
        GameObject.Destroy(targetThree);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
