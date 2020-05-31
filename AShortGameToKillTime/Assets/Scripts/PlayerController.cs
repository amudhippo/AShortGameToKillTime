using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    private new Rigidbody rigidbody;
    private bool paused;
    void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            //MouseX spins the Y axis turning you left, or right.
            float mouseX = Input.GetAxis("Mouse X");
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float yRot = (transform.eulerAngles.y + turnSpeed * mouseX) % 360f;

            if (yRot < 0f)
            {
                yRot += 360f;
            }
            transform.eulerAngles = new Vector3(0f, yRot, 0f);


            if (horizontal != 0f || vertical != 0f)
            {
                Vector3 okay = new Vector3(horizontal, 0f, vertical);
                float magnitude = Mathf.Clamp(okay.magnitude, 0, 1);
                okay.Normalize();
                okay *= magnitude;
                rigidbody.MovePosition(Vector3.Lerp(rigidbody.position, transform.TransformPoint(okay), 5f * Time.deltaTime));
            }
            //TODO: Is player touching the ground after move?
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "lazy_no_fall")
        {
            print("NO FALL");
            rigidbody.position = new Vector3(28.2f, 10, 65.8f);
        }
    }

    public void Pause()
    {
        paused = true;
        rigidbody.useGravity = false;
    }

    public void UnPause()
    {
        paused = false;
        rigidbody.useGravity = true;
    }

}
