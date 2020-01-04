using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;

    UnityStandardAssets.Characters.FirstPerson.FirstPersonController moveScript;

    float notTired = 9f;
    float tired = 5f;

    float stamina = 1f;
    float staminaDepleteTime = 5f;
    float staminaRegenTime = 3f;
    bool running = false;

    private void Start()
    {
        staminaBar.value = stamina;

        moveScript = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    void Update()
    {

        running = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= Time.deltaTime / staminaDepleteTime;
            if (stamina > 0f)
            {
                running = true;
            }
        }
        else
        {
            stamina += Time.deltaTime / staminaRegenTime;
        }

        stamina = Mathf.Clamp01(stamina);

        if (running)
        {
            moveScript.m_RunSpeed = notTired;
        }
        else
        {
            moveScript.m_RunSpeed = tired;
        }

        staminaBar.value = stamina;

    }
}
