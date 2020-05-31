using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AtmosphereController : MonoBehaviour
{
    public bool darkening;
    private float lightsideAngle;
    private float darksideAngle;
    // Start is called before the first frame update
    void Start()
    {
        darkening = false;
        lightsideAngle = 295f;
        darksideAngle = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        float expectedAngle;
        Vector3 direction;
        if (!darkening)
        {
            expectedAngle = lightsideAngle;
            direction = -transform.forward;
        }
        else
        {
            expectedAngle = darksideAngle;
            direction = transform.forward;
        }
        if (Mathf.Abs(expectedAngle - transform.eulerAngles.z) > 1)
        {
            transform.Rotate(direction * Time.deltaTime * 100);
        }
    }

    void FlipSwitch()
    {
        darkening = !darkening;
    }
}
