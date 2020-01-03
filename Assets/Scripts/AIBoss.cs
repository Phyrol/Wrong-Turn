using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    Pathfinding.RichAI aiScript;

    // Start is called before the first frame update
    void Start()
    {
        aiScript = GetComponent<Pathfinding.RichAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, this.transform.position) < 4)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);
        }

        if(Vector3.Distance(player.position, this.transform.position) > 12)
        {
            aiScript.maxSpeed = 7;
        }
        else
        {
            aiScript.maxSpeed = 5;
        }
    }
}
