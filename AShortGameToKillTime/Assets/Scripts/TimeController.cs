using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    //TODO This is public for testing purposes. Please remove.
    public float startingTime;
    public GameObject player;
    public GameObject atmosphere;
    public GameObject socketPanel;
    public GameObject gameOverController;
    private AudioSource ticking;
    private AudioSource bellTolling;
    private AudioSource drone;
    //TODO maybe find a way to get this from timePanel.
    public Text uiTimer;
    public GameObject timePanel;
    public Image dangerMeter;
    public Image dangerMeterHand;
    public Image watchedIndicator;
    public Sprite watched;
    public Sprite notWatched;
    private float timeRemaining;
    private float damageIntervalTracker;
    private float damageIntervalLength;
    bool playerMarked;
    bool damageAllowed;
    bool paused;

    List<GameObject> clocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sources = this.GetComponents<AudioSource>();
        foreach(AudioSource source in this.GetComponents<AudioSource>())
        {
            switch (source.clip.name)
            {
                case "ticking":
                    ticking = source;
                    break;
                case "BellsTolling":
                    bellTolling = source;
                    break;
                case "Drone":
                    drone = source;
                    break;
            }
        }
        ticking = sources[0];
        bellTolling = sources[1];
        timeRemaining = startingTime * 60;
        damageIntervalTracker = 10;
        damageIntervalLength = 10;
        playerMarked = false;
        damageAllowed = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (playerMarked)
            {
                watchedIndicator.sprite = watched;
            }
            else
            {
                watchedIndicator.sprite = notWatched;
            }
            if (timeRemaining > 1)
            {
                Vector3 dmhForward = (this.GetComponent<Transform>()).forward;
                dangerMeterHand.transform.Rotate(-dmhForward * 36 * Time.deltaTime, Space.World);
                if (playerMarked && damageAllowed)
                {
                    ticking.volume = 1f;
                    ticking.pitch = 1.25f;
                    drone.volume = 1f;
                    timeRemaining -= Time.deltaTime;
                    uiTimer.color = new Color(1f, 0f, 0f);
                    long secondsNumeric = (long)timeRemaining % 60;
                    string secondsString = secondsNumeric.ToString();
                    if (secondsNumeric < 10)
                    {
                        secondsString = "0" + secondsNumeric.ToString();
                    }
                    uiTimer.text = (long)(timeRemaining / 60) + ":" + secondsString;
                } else
                {
                    ticking.pitch = 1f;
                    ticking.volume = .5f;
                    drone.volume -= .75f * Time.deltaTime;
                }
                if (!damageAllowed)
                {
                    bellTolling.volume -= .45f * Time.deltaTime;
                } else
                {
                    bellTolling.volume += .45f * Time.deltaTime;
                }
                if (uiTimer.color.r == 1f && (!damageAllowed || !playerMarked))
                {
                    uiTimer.color = new Color(1, 1, 1);
                }
                if (damageIntervalTracker > 0)
                {
                    if (damageAllowed == true)
                    {
                        dangerMeter.color = Color.red;
                    }
                    else if (damageIntervalTracker > 3)
                    {
                        dangerMeter.color = Color.white;
                    }
                    else
                    {
                        dangerMeter.color = new Color(1.0f, 0.64f, 0.0f);
                    }
                    damageIntervalTracker -= Time.deltaTime;
                }
                else
                {
                    damageAllowed = !damageAllowed;
                    atmosphere.SendMessage("FlipSwitch");
                    damageIntervalTracker = damageIntervalLength;
                }
                playerMarked = false;
                foreach (GameObject clock in clocks)
                {
                    clock.SendMessage("MarkRemoved");
                }
            }
            else
            {
                //This is temporary. There's a better way to end the game, but I want the skeleton in place first.
                //This should be triggering something instead of just setting these panels to active.
                timePanel.SetActive(false);
                socketPanel.SetActive(false);
                gameOverController.SendMessage("GameLost");
            }
        }
        
        
        //TODO tell all clocks that a tick has been recorded.
    }

    void MarkPlayer()
    {
        playerMarked = true;
        foreach(GameObject clock in clocks)
        {
            clock.SendMessage("PlayerMarked");
        }
    }

    void SubscribeClock(GameObject clock)
    {
        clocks.Add(clock);
    }

    void UnSubscribeClock(GameObject clock)
    {
        clocks.Remove(clock);
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
