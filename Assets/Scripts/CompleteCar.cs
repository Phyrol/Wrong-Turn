using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteCar : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCursor;
    public GameObject subText;
    private int remainingParts = 0;
    private bool pressedE = false;

    [Header("End Game")]
    public GameObject player;
    public GameObject endCam;
    public GameObject bigBoss;
    public AudioSource ambient;
    public AudioSource ending;
    public Canvas playerCanvas;

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
                    subText.GetComponent<Text>().text = "Congratulations! You won!";
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    ExtraCursor.SetActive(false);
                    endCam.SetActive(true);
                    Destroy(player);
                    Destroy(bigBoss);
                    ambient.Stop();
                    ending.Play();
                    playerCanvas.enabled = false;
                }
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

}