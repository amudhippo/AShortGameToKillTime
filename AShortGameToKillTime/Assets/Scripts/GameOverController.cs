using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject player;
    public GameObject LosingGameOverScreen;
    public GameObject WinningGameOverScreen;
    bool gameOver;
    float endGameTimer = 5;
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
            endGameTimer -= 1 * Time.deltaTime;
            print(endGameTimer);
            if (endGameTimer < 0)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }
        }
    }

    public void GameLost()
    {
        Rigidbody rigidBody = player.GetComponent<Rigidbody>();
        rigidBody.MovePosition(new Vector3(1000, 1000, 1000));
        rigidBody.useGravity = false;
        LosingGameOverScreen.SetActive(true);
        gameOver = true;
    }

    public void GameWon()
    {
        //If you decide on another way to end the game. Get rid of this :)
        Rigidbody rigidBody = player.GetComponent<Rigidbody>();
        rigidBody.MovePosition(new Vector3(1000, 1000, 1000));
        rigidBody.useGravity = false;
        WinningGameOverScreen.SetActive(true);
        gameOver = true;
    }
}
