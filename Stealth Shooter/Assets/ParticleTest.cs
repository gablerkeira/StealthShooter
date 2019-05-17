using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    public ParticleSystem Soundgun;
    public AudioClip FiringGun;
    public AudioSource ShootGun;

    private void Start()
    {
        ShootGun = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        Soundgun.Play();
        ShootGun.Play();

        print("We got noise!");
    }
}
