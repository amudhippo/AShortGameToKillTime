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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseSwitch();
        }
    }
    
    public void PauseSwitch()
    {
        if (paused)
        {
            if (Cursor.lockState == CursorLockMode.None || Cursor.lockState == CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            player.SendMessage("UnPause");
            timeController.SendMessage("UnPause");
            cameraController.SendMessage("UnPause");
            PauseMenu.SetActive(false);
        }
        else
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            player.SendMessage("Pause");
            timeController.SendMessage("Pause");
            cameraController.SendMessage("Pause");
            PauseMenu.SetActive(true);
        }
        paused = !paused;
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
