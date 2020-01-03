using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleZombie : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    Pathfinding.RichAI aiScript;

    // Start is called before the first frame update
    void Start()
    {
        aiScript = GetComponent<Pathfinding.RichAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, this.transform.position) < 26)
        {
            aiScript.enabled = true;
            Vector3 direction = player.position - this.transform.position;
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
            aiScript.enabled = false;
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
