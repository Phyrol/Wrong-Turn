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

    public Slider healthBar;

    void Start()
    {
         //max health
        maxHealth = 100f;
        healthBar.value = maxHealth;
    }

    public void takeDamage(float damage)
    {
        //if player is dealt damage player will lose health
        healthBar.value -= damage;
        audioSource.PlayOneShot(hurtSound, 2f);

        if(healthBar.value <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("You have died.");
        SceneManager.LoadScene("Main");

    }
}
