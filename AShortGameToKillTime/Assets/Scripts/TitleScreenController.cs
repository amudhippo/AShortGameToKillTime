using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject clockTower;
    public GameObject directionsScreen;
    public Text hook;
    public Text goal;
    public Text rulesOne;
    public Text rulesTwo;
    public Text rulesThree;
    public Text red;
    public Text green;
    public Text blue;
    public Image redSword;
    public Image greenSword;
    public Image blueSword;
    public Text goodLuck;
    public Text continueText;
    public float textSpeed;
    
    private Image directionsImage;
    int phase;
    int swordsPhase;
    // Start is called before the first frame update
    void Start()
    {
        directionsImage = directionsScreen.GetComponent<Image>();
        phase = 0;
        swordsPhase = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.RotateAround(clockTower.transform.position, Vector3.up, Time.deltaTime * 8);
        if (phase >= 1 && Input.GetMouseButtonDown(0))
        {
            GoToClockTowerScene();
        }
        switch (phase)
        {
            //Directions screen begin!
            case 1:
                if (directionsImage.color.a < 1)
                {
                    directionsImage.color = new Color(directionsImage.color.r, directionsImage.color.g, directionsImage.color.b, directionsImage.color.a + Time.deltaTime * textSpeed);
                } else
                {

                    phase += 1;
                }
                break;

            //Display story hook
            case 2:
                if (hook.color.a < 1)
                {
                    hook.color = new Color(hook.color.r, hook.color.g, hook.color.b, hook.color.a + Time.deltaTime * textSpeed);
                }
                else
                {
                    phase += 1;
                }
                break;

            //Display in-game goal
            case 3:
                if (hook.color.b < 1)
                {
                    hook.color = new Color(hook.color.r + Time.deltaTime * textSpeed, hook.color.g + Time.deltaTime * textSpeed, hook.color.b + Time.deltaTime * textSpeed);
                }
                if (goal.color.a < 1)
                {
                    goal.color = new Color(goal.color.r, goal.color.g, goal.color.b, goal.color.a + Time.deltaTime * textSpeed);
                }
                else
                {
                    phase += 1;
                }
                break;

            //displayswords, then remove swords.
            case 4:
                if (goal.color.b < 1)
                {
                    goal.color = new Color(goal.color.r + Time.deltaTime * textSpeed, goal.color.g + Time.deltaTime * textSpeed, goal.color.b + Time.deltaTime * textSpeed);
                } else
                {
                    if (swordsPhase < 1)
                    {
                        swordsPhase = 1;
                    }
                }
                switch (swordsPhase)
                {
                    
                    case 1:
                        if (red.color.a < 1)
                        {
                            red.color = new Color(red.color.r, red.color.g, red.color.b, red.color.a + Time.deltaTime * textSpeed);
                            redSword.color = new Color(redSword.color.r, redSword.color.g, redSword.color.b, redSword.color.a + Time.deltaTime * textSpeed);
                        }
                        else
                        {

                            swordsPhase += 1;
                        }
                        break;
                    case 2:
                        if (red.color.a > 0)
                        {
                            red.color = new Color(red.color.r, red.color.g, red.color.b, red.color.a - Time.deltaTime * textSpeed);
                            redSword.color = new Color(redSword.color.r, redSword.color.g, redSword.color.b, redSword.color.a - Time.deltaTime * textSpeed);
                        }
                        if (green.color.a < 1)
                        {
                            green.color = new Color(green.color.r, green.color.g, green.color.b, green.color.a + Time.deltaTime * textSpeed);
                            greenSword.color = new Color(greenSword.color.r, greenSword.color.g, greenSword.color.b, greenSword.color.a + Time.deltaTime * textSpeed);
                        }

                        else
                        {
                            swordsPhase += 1;
                        }
                        break;
                    case 3:
                        if (green.color.a > 0)
                        {
                            green.color = new Color(green.color.r, green.color.g, green.color.b, green.color.a - Time.deltaTime * textSpeed);
                            greenSword.color = new Color(greenSword.color.r, greenSword.color.g, greenSword.color.b, greenSword.color.a - Time.deltaTime * textSpeed);
                        }
                        if (blue.color.a < 1)
                        {
                            blue.color = new Color(blue.color.r, blue.color.g, blue.color.b, blue.color.a + Time.deltaTime * textSpeed);
                            blueSword.color = new Color(blueSword.color.r, blueSword.color.g, blueSword.color.b, blueSword.color.a + Time.deltaTime * textSpeed);
                        }
                        else
                        {
                            swordsPhase += 1;
                        }
                        break;
                    case 4:
                        if (blue.color.a > 0)
                        {
                            blue.color = new Color(blue.color.r, blue.color.g, blue.color.b, blue.color.a - Time.deltaTime * textSpeed);
                            blueSword.color = new Color(blueSword.color.r, blueSword.color.g, blueSword.color.b, blueSword.color.a - Time.deltaTime * textSpeed);
                        }
                        else
                        {
                            phase += 1;
                        }
                        break;
                    default:
                        break;
                }
                break;

            //display rules of the game.
            case 5:
                if (rulesOne.color.a < 1)
                {
                    rulesOne.color = new Color(rulesOne.color.r, rulesOne.color.g, rulesOne.color.b, rulesOne.color.a + Time.deltaTime * textSpeed);
                }
                else
                {
                    phase += 1;
                }
                break;
            case 6:
                if (rulesOne.color.b < 1)
                {
                    rulesOne.color = new Color(rulesOne.color.r + Time.deltaTime, rulesOne.color.g + Time.deltaTime, rulesOne.color.b + Time.deltaTime * textSpeed);
                }
                if (rulesTwo.color.a < 1)
                {
                    rulesTwo.color = new Color(rulesTwo.color.r, rulesTwo.color.g, rulesTwo.color.b, rulesTwo.color.a + Time.deltaTime * textSpeed);
                }
                else
                {
                    phase += 1;
                }
                break;
            case 7:
                if (rulesTwo.color.b < 1)
                {
                    rulesTwo.color = new Color(rulesTwo.color.r + Time.deltaTime, rulesTwo.color.g + Time.deltaTime, rulesTwo.color.b + Time.deltaTime * textSpeed);
                }
                if (rulesThree.color.a < 1)
                {
                    rulesThree.color = new Color(rulesThree.color.r, rulesThree.color.g, rulesThree.color.b, rulesThree.color.a + Time.deltaTime * textSpeed);
                }
                else
                {
                    textSpeed = .25f;
                    phase += 1;
                }
                break;
            //display good luck message.
            case 8:
                if (rulesThree.color.b < 1)
                {
                    rulesThree.color = new Color(rulesThree.color.r + Time.deltaTime, rulesThree.color.g + Time.deltaTime, rulesThree.color.b + Time.deltaTime * textSpeed);
                }
                if (goodLuck.color.a < 1)
                {
                    goodLuck.color = new Color(goodLuck.color.r, goodLuck.color.g, goodLuck.color.b, goodLuck.color.a + Time.deltaTime * textSpeed);
                }
                else
                {
                    phase += 1;
                }
                break;
            //display continue text
            case 9:
                if (continueText.text == "Click anywhere on the screen to skip the rules and start immediately...")
                {
                    continueText.text = "Click anywhere on this screen to start...";
                }
                else
                {
                    phase += 1;
                }
                break;
            default:
                break;
        }
    }

    public void GoToDirectionsScreen()
    {
        phase = 1;
        directionsScreen.SetActive(true);
    }

    public void GoToClockTowerScene()
    {
        SceneManager.LoadScene("ClockTower");
    }
}
