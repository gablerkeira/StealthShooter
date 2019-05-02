﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator playerAnimator;
    public Action OnDie = delegate { };
    public Action<GameObject> OnChoke = delegate { };
    [Tooltip("List of nearby enemies to the player")]
    public List<GameObject> nearbyEnemy;
    Ray mousePoint;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().OnFire += Attack;
    }

    void Start()
    {
        nearbyEnemy = new List<GameObject>();
        playerAnimator = gameObject.GetComponent<Animator>();

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
                playerAnimator.SetBool("ChokeEm", true);
                StartCoroutine(WaitToChoke());
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                mousePoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
        }
    }

    IEnumerator WaitToChoke()
    {
        OnChoke(nearbyEnemy[0]);
        Collider playerCol = GetComponent<Collider>();
        playerCol.isTrigger = true;
        Rigidbody playerRb = GetComponent<Rigidbody>();
        playerRb.useGravity = false;

        yield return new WaitForSeconds(3.2f);

        playerAnimator.SetBool("ChokeEm", false);
        RemoveEnemy(nearbyEnemy[0]);
        OnDie();
        playerCol.isTrigger = false;
        playerRb.useGravity = true;
    }
}