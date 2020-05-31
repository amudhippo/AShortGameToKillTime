using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject backpack;
    public GameObject canvas;
    public Camera mainCamera;
    public GameObject breakableInteraction;
    public GameObject collectableInteraction;
    public GameObject useableInteraction;
    private List<GameObject> targetQueue;
    private GameObject target;

    void Start()
    {
        targetQueue = new List<GameObject>();
        target = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Breakable" || other.gameObject.tag == "Collectable" || other.gameObject.tag == "Useable")
        {
           targetQueue.Add(other.gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Breakable" || other.gameObject.tag == "Collectable" || other.gameObject.tag == "Useable")
        {
            targetQueue.Remove(other.gameObject);
        }
    }





    void Update()
    {
        if (targetQueue.Count > 0)
        {
            target = targetQueue[targetQueue.Count - 1];
            
            GameObject panel = null;
            switch (target.tag)
            {
                case "Breakable":
                    breakableInteraction.SetActive(true);
                    collectableInteraction.SetActive(false);
                    useableInteraction.SetActive(false);
                    panel = breakableInteraction;
                    break;
                case "Collectable":
                    collectableInteraction.SetActive(true);
                    breakableInteraction.SetActive(false);
                    useableInteraction.SetActive(false);
                    panel = collectableInteraction;
                    break;
                case "Useable":
                    useableInteraction.SetActive(true);
                    collectableInteraction.SetActive(false);
                    breakableInteraction.SetActive(false);
                    panel = useableInteraction;
                    break;
                default:
                    break;
            }
            panel.transform.position = mainCamera.WorldToScreenPoint(target.transform.position);
        } else
        {
            target = null;
            //TODO move them into a single panel that we can turn on and off.
            collectableInteraction.SetActive(false);
            breakableInteraction.SetActive(false);
            useableInteraction.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        if(target != null)
        {
            switch (target.tag)
            {
                case "Breakable":
                    targetQueue.Remove(target);

                    //TODO Add an animation, and a timer before destroy occurs.
                    Destroy(target);
                    break;
                case "Collectable":
                    targetQueue.Remove(target);

                    object[] message = new object[2];
                    message[0] = target.name;
                    message[1] = target;
                    backpack.SendMessage("AddToInventory", message);
                    collectableInteraction.SetActive(false);
                    break;
                case "Useable":
                    target.SendMessage("Use");
                    break;
                default:
                    break;
            }
            if (target.tag == "Breakable")
            {

            }
            else if (target.tag == "Collectable")
            {

            }
        }
    }
}
