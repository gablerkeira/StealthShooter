using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RaiseGun : MonoBehaviour
{
    public Animator animator;
    bool isGunRaised = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGunRaised == false)
            {
                animator.SetBool("RaiseGun", true);
                isGunRaised = true;
            }
            else if(isGunRaised == true)
            {
                animator.SetBool("RaiseGun", false);
                isGunRaised = false;
            }
        }
    }
}
