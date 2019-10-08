using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBeam : MonoBehaviour
{
    public int beamDamage = 6;
    public float fireRate = .75f;
    public float weaponRange = 50f;
    public float timer;
    //flashlight end raycast
    Ray beamRay;

    //raycast hit information
    RaycastHit beamHit;

    //ray only hits objects in shootable layer
    int shootableMask;

    //reference to particle system
   ParticleSystem beamParticles;

    //reference to line renderer
   LineRenderer beamLine;
    
    //reference to audio
   AudioSource beamAudio;

    //reference to light
    Light beamLight;

    //prop of the firerate that effects will display
    float effectsDisplayTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //laser mask for shootable layer
        shootableMask = LayerMask.GetMask("Shootable");

        //references
        beamParticles = GetComponent<ParticleSystem>();
        beamLine = GetComponent<LineRenderer>();
        beamAudio = GetComponent<AudioSource>();
        beamLight = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //time since update was called timer last
        timer += Time.deltaTime;

        //if F key is pressed
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer >= fireRate)
        {
            //shoot the beam
            Shoot();
        }

        //if timer has exceeded no effect will happen
       if (timer >= fireRate * effectsDisplayTime)
        {
            DisableEffects();
        }
        
    }

    public void DisableEffects()
    {
        //disable light and line renderer
        beamLine.enabled = false;
        beamLight.enabled = false;
    }

    void Shoot()
    {

        //reset timer
        timer = 0f;

        // Play the beam audio
        beamAudio.Play();

        // light is enabled
        beamLight.enabled = true;

        // stop and start particle system
        beamParticles.Stop();
        beamParticles.Play();

        //line renderer is enabeled and applied to end of flashlight
        beamLine.enabled = true;
        beamLine.SetPosition(0, transform.position);

        // Set beamray to shoot from the flashlight end forward
        beamRay.origin = transform.position;
        beamRay.direction = transform.forward;

        // Raycast against objects in shootable layer
        if (Physics.Raycast(beamRay, out beamHit, weaponRange, shootableMask))
        {
            // find enemyhealth script in object hit
            EnemyHealth enemyHealth = beamHit.collider.GetComponent<EnemyHealth>();

            // If enemyhealth exists
            if (enemyHealth != null)
            {
                // then deal damage to enemy
                enemyHealth.takeDamage(beamDamage, beamHit.point);
            }

            // Second position to where beamhit hit
            beamLine.SetPosition(1, beamHit.point);
        }
        // if nothing was hit
        else
        {
            //set to beam's furthest range
            beamLine.SetPosition(1, beamRay.origin + beamRay.direction * weaponRange);
        }
    }
}