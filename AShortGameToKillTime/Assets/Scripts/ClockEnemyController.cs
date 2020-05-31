using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockEnemyController : MonoBehaviour
{
    //TODO for some reason the "interaction mesh" is counted as part of the Player
    public GameObject target;
    public GameObject globalTimer;
    public int range;
    private bool markedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        markedPlayer = false;
        globalTimer.SendMessage("SubscribeClock", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(transform.position, target.transform.position) < range && !markedPlayer)
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, target.transform.position, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    globalTimer.SendMessage("MarkPlayer");
                }
            }
                
        }
    }

    void PlayerMarked()
    {
        markedPlayer = true;
    }
    
    void MarkRemoved()
    {
        markedPlayer = false;
    }

    private void OnDestroy()
    {
        if (globalTimer != null)
        {
            globalTimer.SendMessage("UnSubscribeClock", this.gameObject);
        }
    }
}
