using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScream : MonoBehaviour
{
    AudioSource myAudio;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        count++;
        print(count);
        if (count >= 5400)
        {
            myAudio.Play(0);
            count = 0;
        }
    }
}
