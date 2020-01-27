using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light myLight;

    private bool isOn;

    private AudioSource playerAudio => GetComponent<AudioSource>();
    public AudioClip flashlightSwitch;
    private float clipVolume = 1f;

    private void Start()
    {
        isOn = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(isOn)
            {
                myLight.enabled = false;
                isOn = false;
                PlaySound();
            }
            else
            {
                myLight.enabled = true;
                isOn = true;
                PlaySound();
            }
        }
    }

    void PlaySound()
    {
        playerAudio.PlayOneShot(flashlightSwitch, clipVolume);
    }
}

