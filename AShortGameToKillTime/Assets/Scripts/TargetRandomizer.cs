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
        GameObject targetTwo = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        GameObject targetThree = possibleLocations[Random.Range(0, possibleLocations.Length - 1)];
        redSword.transform.position = targetOne.transform.position;
        redSword.transform.eulerAngles = targetOne.transform.eulerAngles;
        blueSword.transform.position = targetTwo.transform.position;
        blueSword.transform.eulerAngles = targetTwo.transform.eulerAngles;
        greenSword.transform.position = targetThree.transform.position;
        greenSword.transform.eulerAngles = targetThree.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
