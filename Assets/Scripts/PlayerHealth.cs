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
    public AudioClip zombieAttack1;
    public AudioClip zombieAttack2;
    public AudioClip zombieAttack3;
    private float clipVolume;
    AudioSource audioSource => GetComponent<AudioSource>();

    //boolean condition to check if player is dead
    bool isDead;

    //max health
    private float maxHealth;

    public Slider healthBar;

    void Start()
    {
        clipVolume = 1.5f;

         //max health
        maxHealth = 100f;
        healthBar.value = maxHealth;
    }

    public void takeDamage(float damage)
    {
        //if player is dealt damage player will lose health
        ZombieAttackSound();
        healthBar.value -= damage;
        audioSource.PlayOneShot(hurtSound, clipVolume);

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

    void ZombieAttackSound()
    {
        int rnd = Random.Range(0, 3);

        switch(rnd)
        {
            case 0:
                audioSource.PlayOneShot(zombieAttack1, clipVolume);
                break;
            case 1:
                audioSource.PlayOneShot(zombieAttack2, clipVolume);
                break;
            case 2:
                audioSource.PlayOneShot(zombieAttack3, clipVolume);
                break;
            default:
                break;
        }
    }
}
