using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject player;
    public GameObject losingGameOverScreen;
    public GameObject winningGameOverScreen;
    public GameObject timeController;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void GameLost()
    {
        timeController.SendMessage("Pause");
        Rigidbody rigidBody = player.GetComponent<Rigidbody>();
        rigidBody.MovePosition(new Vector3(1000, 1000, 1000));
        rigidBody.useGravity = false;
        losingGameOverScreen.SetActive(true);
        gameOver = true;
    }

    public void GameWon()
    {
        //If you decide on another way to end the game. Get rid of this :)
        timeController.SendMessage("Pause");
        Rigidbody rigidBody = player.GetComponent<Rigidbody>();
        rigidBody.MovePosition(new Vector3(1000, 1000, 1000));
        rigidBody.useGravity = false;
        winningGameOverScreen.SetActive(true);
        gameOver = true;
    }
}
