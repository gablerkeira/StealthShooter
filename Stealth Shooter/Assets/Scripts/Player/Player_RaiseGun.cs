using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RaiseGun : MonoBehaviour
{
    public Animator animator;
    public bool isGunRaised = false;
    public bool haveSoundGun = false;
    public GameObject SoundGun;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnGetSoundGun += HaveSoundGun;
    }

    public void HaveSoundGun()
    {
        haveSoundGun = true;
        SoundGun.SetActive(true);
        animator.SetBool("RaiseGun", false);
    }

    void Update()
    {
        if (haveSoundGun == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isGunRaised == false)
                {
                    animator.SetBool("RaiseGun", true);
                    isGunRaised = true;
                }
                else if (isGunRaised == true)
                {
                    animator.SetBool("RaiseGun", false);
                    isGunRaised = false;
                }
            }
        }
    }
}
