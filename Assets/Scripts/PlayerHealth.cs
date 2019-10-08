using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //players current health
    private float playerHealth;

    //audio for hurt sound effect
    public AudioClip hurtSound;
    AudioSource audioSource => GetComponent<AudioSource>();

    //boolean condition to check if player is dead
    bool isDead;

    //max health
    private float maxHealth;

    public Text healthText;

    void Start()
    {
         //max health
        maxHealth = 100f;
        playerHealth = maxHealth;

        healthText.text = "Health: " + playerHealth + "/" + maxHealth;
    }

    //test to make sure health bar takes damage
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            takeDamage(3);
    }

    public void takeDamage(float damage)
    {
        //if player is dealt damage player will lose health
        playerHealth -= damage;
        audioSource.PlayOneShot(hurtSound, 2f);
        healthText.text = "Health: " + playerHealth + "/" + maxHealth;
        if(playerHealth <= 0)
        {
            healthText.text = "Health: 0/" + maxHealth;
            Death();
        }
    }

    float CalculateHealth()
    {
        return playerHealth / maxHealth;
    }

    public void Death()
    {
        Debug.Log("You have died.");
        SceneManager.LoadScene("Main");

    }
}
