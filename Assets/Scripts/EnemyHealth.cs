using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //healthbar
    public Slider EnemyHealthBar;

    //audio for hurt sound effect
    public AudioSource hurtSound;

    //max health
    public float maxHealth;

    //current enemy health
    public float enemyHealth;

    //enemy capsule collider
    CapsuleCollider capsuleCollider;

    //particle system reference
    ParticleSystem lightParticles;

    //boolean condition to check if dead
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //max health
        maxHealth = 20f;

        //sound for enemy hurt
        hurtSound = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        lightParticles = GetComponent<ParticleSystem>();

        //set enemy health to max health
        enemyHealth = maxHealth;

        //get health percentage value
        EnemyHealthBar.value = CalculateHealth();

    }

    public void takeDamage(int beamDamage, Vector3 beamPoint)
    {
        //if enmey is dead then dont take damage
      //  if (isDead)

            //exit function
        //    return;

        //play hurt sound
        hurtSound.Play();

        //take damage to health
        enemyHealth -= beamDamage;

        //reference value to health bar
        EnemyHealthBar.value = CalculateHealth();

        //set particle systme positon to where the hit occured
        lightParticles.transform.position = beamPoint;

        //play particle system
        lightParticles.Play();

        if (enemyHealth <= 0 && !isDead)
        {
            Death();
            //gameObject.SetActive(false);
        }
    }

    float CalculateHealth()
    {
        return enemyHealth / maxHealth;
    }

    void Death()
    {
        isDead = true;

        hurtSound.Play();

        enemyHealth = 0;
        Debug.Log("One enemy dead.");
        //disable the nav mesh agent
        //GetComponent<NavMeshAgent>().enabled = false;

        //after 3 seconds destroy enemy
        //Destroy(gameObject, 3f);
    }

}
