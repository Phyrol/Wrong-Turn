﻿using System.Collections;
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
        myAudio.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count >= 1600)
        {
            myAudio.Play(0);
            count = 0;
        }
    }
}
