using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AtmosphereController : MonoBehaviour
{
    public bool darkening;
    public Light sun;
    private Color safeColor;
    private float lightsideAngle;
    private float darksideAngle;
    // Start is called before the first frame update
    void Start()
    {
        darkening = false;
        lightsideAngle = 295f;
        darksideAngle = 30f;
        safeColor = sun.color;
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
            sun.color = safeColor;
        }
        else
        {
            expectedAngle = darksideAngle;
            direction = transform.forward;
            sun.color = Color.red;
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
