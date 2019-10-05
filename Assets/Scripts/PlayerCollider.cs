using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    public Text playerText;

    private int stateCounter;
    private bool gotEngine, gotGasoline, gotBattery;

    // Start is called before the first frame update
    void Start()
    {
        stateCounter = 0;
        gotEngine = false;
        gotGasoline = false;
        gotBattery = false;
        playerText.text = "Find the remaining car parts!";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Engine"))
        {
            stateCounter++;
            other.gameObject.SetActive(false);
            gotEngine = true;
            playerText.text = "Find the remaining "+ (3-stateCounter) +" car parts!";
        }

        if (other.gameObject.CompareTag("Gasoline"))
        {
            stateCounter++;
            other.gameObject.SetActive(false);
            gotGasoline = true;
            playerText.text = "Find the remaining " + (3 - stateCounter) + " car parts!";
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            stateCounter++;
            other.gameObject.SetActive(false);
            gotBattery = true;
            playerText.text = "Find the remaining " + (3 - stateCounter) + " car parts!";
        }

        if(stateCounter == 3)
        {
            playerText.text = "Return to the car and escape! Quickly!";
        }
    }
}
