using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleZombie : MonoBehaviour
{
    private GameObject player;
    public Animator anim;
    Pathfinding.RichAI aiScript;

    public AudioSource playerAudio;
    public AudioClip zombieAlert1;
    public AudioClip zombieAlert2;
    public AudioClip zombieAlert3;

    private float clipVolume = 1f;

    private bool alerted = false;

    // Start is called before the first frame update
    void Start()
    {
        aiScript = GetComponent<Pathfinding.RichAI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) < 28)
        {
            if(!alerted)
            {
                AlertSound();
                alerted = true;
            }

            aiScript.enabled = true;
            Vector3 direction = player.transform.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if(direction.magnitude > 1.5)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            alerted = false;
            aiScript.enabled = false;
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }

    void AlertSound()
    {
        int rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 0:
                playerAudio.PlayOneShot(zombieAlert1, clipVolume);
                break;
            case 1:
                playerAudio.PlayOneShot(zombieAlert2, clipVolume);
                break;
            case 2:
                playerAudio.PlayOneShot(zombieAlert3, clipVolume);
                break;
            default:
                break;
        }
    }
}
