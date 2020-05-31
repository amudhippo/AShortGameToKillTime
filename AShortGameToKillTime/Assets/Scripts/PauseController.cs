using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject player;
    public GameObject timeController;
    public GameObject cameraController;
    public GameObject PauseMenu;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                player.SendMessage("UnPause");
                timeController.SendMessage("UnPause");
                cameraController.SendMessage("UnPause");
                PauseMenu.SetActive(false);
            }
            else
            {
                player.SendMessage("Pause");
                timeController.SendMessage("Pause");
                cameraController.SendMessage("Pause");
                PauseMenu.SetActive(true);
            }
            paused = !paused;
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
