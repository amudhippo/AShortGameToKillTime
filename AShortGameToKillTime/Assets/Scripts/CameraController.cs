using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float turnSpeed;
    float xRot;
    private bool paused;
    private Skybox skyBox;

    void Start()
    {
        paused = false;
        skyBox = this.GetComponent<Skybox>();
        skyBox.material.color = Color.black;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!paused)
        {
            float yRot = transform.eulerAngles.y;
            float mouseY = -Input.GetAxis("Mouse Y");
            xRot += turnSpeed * mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);
            transform.eulerAngles = new Vector3(xRot, yRot, 0f);
        }
    }

    public void Pause()
    {
        paused = true;
    }

    public void UnPause()
    {
        paused = false;
    }
}
