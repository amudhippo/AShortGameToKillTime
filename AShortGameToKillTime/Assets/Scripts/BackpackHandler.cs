using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackHandler : MonoBehaviour
{
    public GameObject redSwordMark;
    public GameObject blueSwordMark;
    public GameObject greenSwordMark;
    public GameObject redSwordFull;
    public GameObject blueSwordFull;
    public GameObject greenSwordFull;
    //This script is solely here to separate out inventory items.
    private IDictionary<string, GameObject> inventory;

    private void Start()
    {
        inventory = new Dictionary<string, GameObject>();
    }

    //item[0] is the key, item[1] is the GameObject we're storing.
    public void AddToInventory(object[] item)
    {
        ((GameObject)item[1]).SetActive(false);
        inventory.Add((string)item[0], (GameObject)item[1]);
        markSwordFound((GameObject)item[1]);
    }



    //item[0] is the key, item[1] is the GameObject we'll be sending it to.
    public void GetItemFromInventory(object[] item)
    {
        if (isItemInInventory((string)item[0]))
        {
            ((GameObject)item[1]).SendMessage("TransferItem", inventory[(string)item[0]]);
            inventory.Remove((string)item[0]);
        }
    }

    private bool isItemInInventory(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

    private void markSwordFound(GameObject sword)
    {
        switch (sword.name)
        {
            case "RedSword":
                redSwordFull.transform.position = redSwordMark.transform.position;
                break;
            case "BlueSword":
                blueSwordFull.transform.position = blueSwordMark.transform.position;
                break;
            case "GreenSword":
                greenSwordFull.transform.position = greenSwordMark.transform.position;
                break;
        }
    }

}
