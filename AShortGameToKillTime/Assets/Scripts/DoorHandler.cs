using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    bool open;
    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        collider = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Use()
    {
        if (open)
        {
            transform.Rotate(Vector3.forward, -90);
            open = false;
            collider.isTrigger = false;
        }
        else
        {
            transform.Rotate(Vector3.forward, 90);
            open = true;
            collider.isTrigger = true;
        }
    }
}
