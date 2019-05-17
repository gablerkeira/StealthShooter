using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    public ParticleSystem Soundgun;

    private void OnMouseDown()
    {
        Soundgun.Play();
    }
}
