using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteCar : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject objectiveText;
    public GameObject ExtraCursor;
    public GameObject subText;
    public GameObject winText;
    public GameObject endText;
    public Slider healthBar;
    public Slider staminaBar;
    private int remainingParts = 0;
    private bool pressedE = false;

    [Header("End Game")]
    public GameObject player;
    public GameObject endCam;
    public GameObject bigBoss;
    public GameObject bossScream;
    public AudioSource ambient;
    public AudioSource ending;
    public AudioSource carStart;
    public Canvas playerCanvas;
    public GameObject fadeOut;
    public Animator anim;

    private bool ended;

    private void Start()
    {
        ended = false;
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }


    void OnMouseOver()
    {
        if (TheDistance <= 10)
        {
            ActionDisplay.GetComponent<Text>().text = "[E]";
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<Text>().text = "Fix Car";
            ActionText.SetActive(true);
            if (pressedE)
            {
                subText.SetActive(true);
            } else
            {
                subText.SetActive(false);
            }

        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        if (!ended)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                subText.SetActive(true);
                pressedE = true;
                if (TheDistance <= 10)
                {
                    remainingParts = CountObjectsWithTag("Engine") + CountObjectsWithTag("Gasoline") + CountObjectsWithTag("Battery");

                    if (remainingParts > 0)
                    {
                        subText.GetComponent<Text>().text = "You don't have all of the car parts! Hurry!";
                        ActionDisplay.SetActive(false);
                        ActionText.SetActive(false);
                    }
                    else
                    {
                        EndGame();
                    }
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(ended)
            {
                EndGame();
            }
        }

    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        subText.SetActive(false);
        pressedE = false;
    }

    private int CountObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag).Length;
    }

    void EndGame()
    {
        DestroyStuff();
        fadeOut.SetActive(true);
        anim.enabled = false;
        anim.enabled = true;
        winText.SetActive(true);
        endText.SetActive(true);
        healthBar.gameObject.SetActive(false);
        staminaBar.gameObject.SetActive(false);
        endCam.SetActive(true);
        ambient.Stop();
        ending.Play();
        carStart.Play();

        ended = true;
    }

    void DestroyStuff()
    {
        Destroy(player);
        Destroy(bigBoss);
        Destroy(bossScream);
        Destroy(ActionDisplay);
        Destroy(ActionText);
        Destroy(ExtraCursor);
        Destroy(subText);
        Destroy(objectiveText);
    }

}