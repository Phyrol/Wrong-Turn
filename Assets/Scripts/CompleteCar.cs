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

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }


    void OnMouseOver()
    {
        if (TheDistance <= 10)
        {
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<Text>().text = "Fix Car";
            ActionText.SetActive(true);
            ExtraCursor.SetActive(true);
        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCursor.SetActive(false);
        }

        if ( Input.GetButtonDown("Action") )
        {
            if (TheDistance <= 3)
            {

                int remainingParts;
                remainingParts = CountObjectsWithTag("Engine") + CountObjectsWithTag("Gasoline") + CountObjectsWithTag("Battery");

                if (remainingParts > 0)
                {
                    subText.GetComponent<Text>().text = "You don't have all of the car parts! Hurray!";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    ExtraCursor.SetActive(false);
                }

                else
                {
                    subText.GetComponent<Text>().text = "Congratulations! You won!";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    ExtraCursor.SetActive(false);
                }

            }
        }
    }

    void OnMouseExit()
    {
        ActionText.SetActive(false);

    }

    private int CountObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag).Length;
    }

}