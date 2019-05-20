using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_OpenDoor : MonoBehaviour
{
    public Animator Animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
        Animator.SetBool("PlayerEnter", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Animator.SetBool("PlayerEnter", false);
    }
}
