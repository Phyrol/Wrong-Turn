using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //healthbar
    public Slider HealthBar;

    //players current health
    public float playerHealth;

    //audio for hurt sound effect
    public AudioSource hurtSound;

    //audio for dead sound effect
    public AudioSource deadSound;

    //boolean condition to check if player is dead
    bool isDead;

    //max health
    public float maxHealth;

    void Start()
    {
         //max health
        maxHealth = 20f;

        //audio
        hurtSound = GetComponent<AudioSource>();
        deadSound = GetComponent<AudioSource>();

        //players health is set to max health at beginning of game
        playerHealth = maxHealth;

        //get health percentage value
        HealthBar.value = CalculateHealth();
    }

    //test to make sure health bar takes damage
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            takeDamage(3);
    }

    public void takeDamage(float damage)
    {
        //if player is dealt damage player will lose health
        playerHealth -= damage;
        HealthBar.value = CalculateHealth();
        hurtSound.Play();
        if (playerHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    float CalculateHealth()
    {
        return playerHealth / maxHealth;
    }

    public void Death()
    {
        isDead = true;

        deadSound.Play();

        playerHealth = 0;
        Debug.Log("You have died.");
        SceneManager.LoadScene("Terrain");

    }

    public void takeHealing(float healing)
    {
        //if player is healed player will gain health
        playerHealth += healing;
        HealthBar.value = playerHealth;
    }
}
