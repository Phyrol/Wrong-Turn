using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //lightSource
    public Light flashlightSource;

    //state of flashlight
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        //getter for light gameobject
        flashlightSource = this.GetComponent<Light>();

        //condition of the state of the flashlight
        //isOn = flashlightSource.enabled;  
    }

    // Update is called once per frame
    void Update()
    {
        //if right mouse click is pressed the state is changed
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //boolean state condition
            //checks if flashlight is already on
            /*if (isOn == true)
            {
                //if it is on then the mouse click will turn it off
                flashlightSource.enabled = false;
                isOn = false;
                soundFlashlight.Play();
            }
            else
            {
                //boolean state condition
                //checks if flashlight is off 
                flashlightSource.enabled = true;
                isOn = true;
                soundFlashlight.Play();
            }*/
        }
        
    }
}

