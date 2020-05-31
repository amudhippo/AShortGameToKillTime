using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class EndGameAltarHandler : MonoBehaviour
{
    public GameObject backpack;
    public GameObject gameOverController;
    public List<string> swords;
    public GameObject redSlot;
    public GameObject blueSlot;
    public GameObject greenSlot;

    private void Start()
    {
        swords = new List<string>();
    }

    private void Update()
    {
        if(swords.Count > 0)
        {
            bool gameComplete = swords.Contains("RedSword") && swords.Contains("BlueSword") && swords.Contains("GreenSword");
            if (gameComplete)
            {
                gameOverController.SendMessage("GameWon");
            }
        }
    }

    void Use()
    {
        object[] message = {"RedSword", this.gameObject};
        backpack.SendMessage("GetItemFromInventory", message);
        message[0] = "BlueSword";
        backpack.SendMessage("GetItemFromInventory", message);
        message[0] = "GreenSword";
        backpack.SendMessage("GetItemFromInventory", message);
    }

    void TransferItem(GameObject sword)
    {
        swords.Add(sword.name);
        switch (sword.name)
        {
            case "RedSword":
                Destroy(redSlot);
                break;
            case "BlueSword":
                Destroy(blueSlot);
                break;
            case "GreenSword":
                Destroy(greenSlot);
                break;
        }
    }
}
