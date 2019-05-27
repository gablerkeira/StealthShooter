using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] shoot;
    public AudioClip beep;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("playing sound");
            int index = Random.Range(0, shoot.Length);
            beep = shoot[index];
            audiosource.clip = beep;
            audiosource.Play();
        }
    }
}
