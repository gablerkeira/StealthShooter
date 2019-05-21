using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator soundGunAnimator;
    public Action OnDie = delegate { };
    public Action<GameObject> OnChoke = delegate { };
    public Action<Vector3> OnShoot = delegate { };
    [Tooltip("List of nearby enemies to the player")]
    public List<GameObject> nearbyEnemy;

    public Action OnGetSoundGun = delegate { };
    public bool haveSoundgun = false;

    Vector3 mousePoint;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().OnFire += Attack;
    }

    void Start()
    {
        nearbyEnemy = new List<GameObject>();
        playerAnimator = gameObject.GetComponent<Animator>();

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enable SoundGun")
        {
            haveSoundgun = true;
            OnGetSoundGun();
        }
    }

    public void AddEnemy(GameObject obj)
    {
        nearbyEnemy.Add(obj);
    }

    public void RemoveEnemy(GameObject obj)
    {
        nearbyEnemy.Remove(obj);
    }


    public void Attack()
    {
        if (nearbyEnemy.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerAnimator.SetBool("SneakAnim", false);
                playerAnimator.SetBool("ChokeEm", true);
                StartCoroutine(WaitToChoke());
            }
            
        }
        if (Input.GetMouseButtonDown(0) && haveSoundgun == true)
        {
            if (GameObject.FindWithTag("MainCamera").GetComponent<Player_RaiseGun>().isGunRaised == true)
            {
                Shoot();
                StartCoroutine(StopTheGun());
            }
        }
    }

    public void Shoot()
    {
        mousePoint = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        
        RaycastHit hit;

        if (Physics.Raycast(mousePoint, Camera.main.transform.forward, out hit))
        {
            Vector3 hitPoint = hit.point;
            
            OnShoot(hitPoint);

            soundGunAnimator.SetBool("Shoot", true);
        }
    }

    IEnumerator StopTheGun()
    {
        yield return new WaitForSeconds(.5f);
        soundGunAnimator.SetBool("Shoot", false);
    }

    IEnumerator WaitToChoke()
    {
        if (nearbyEnemy[0] != null)
        {
            OnChoke(nearbyEnemy[0]);
        }
        Collider playerCol = GetComponent<Collider>();
        playerCol.isTrigger = true;
        Rigidbody playerRb = GetComponent<Rigidbody>();
        playerRb.useGravity = false;

        yield return new WaitForSeconds(.5f);

        playerAnimator.SetBool("ChokeEm", false);
        RemoveEnemy(nearbyEnemy[0]);
        OnDie();
        playerCol.isTrigger = false;
        playerRb.useGravity = true;
    }
}