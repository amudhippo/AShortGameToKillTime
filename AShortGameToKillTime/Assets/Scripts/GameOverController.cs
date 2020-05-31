using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject player;
    public GameObject LosingGameOverScreen;
    public GameObject WinningGameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameLost()
    {
        Rigidbody rigidBody = player.GetComponent<Rigidbody>();
        rigidBody.MovePosition(new Vector3(1000, 1000, 1000));
        rigidBody.useGravity = false;
        LosingGameOverScreen.SetActive(true);
    }

    public void GameWon()
    {
        //If you decide on another way to end the game. Get rid of this :)
        Rigidbody rigidBody = player.GetComponent<Rigidbody>();
        rigidBody.MovePosition(new Vector3(1000, 1000, 1000));
        rigidBody.useGravity = false;

        WinningGameOverScreen.SetActive(true);
    }
}
