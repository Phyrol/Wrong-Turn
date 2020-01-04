using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    public Text playerText;

    private AudioSource playerAudio => GetComponent<AudioSource>();
    public AudioClip collectionSound;
    private float clipVolume = 1f;

    private int stateCounter, partNumber;
    private bool gotEngine, gotGasoline, gotBattery;

    // Start is called before the first frame update
    void Start()
    {
        stateCounter = 0;
        partNumber = 3;
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
            playerText.text = "Find the remaining "+ (partNumber - stateCounter) +" car parts!";
            playerAudio.PlayOneShot(collectionSound, clipVolume);
        }

        if (other.gameObject.CompareTag("Gasoline"))
        {
            stateCounter++;
            other.gameObject.SetActive(false);
            gotGasoline = true;
            playerText.text = "Find the remaining " + (partNumber - stateCounter) + " car parts!";
            playerAudio.PlayOneShot(collectionSound, clipVolume);
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            stateCounter++;
            other.gameObject.SetActive(false);
            gotBattery = true;
            playerText.text = "Find the remaining " + (partNumber - stateCounter) + " car parts!";
            playerAudio.PlayOneShot(collectionSound, clipVolume);
        }

        if(stateCounter == partNumber)
        {
            playerText.text = "Return to the car and escape! Quickly!";
        }
    }
}
