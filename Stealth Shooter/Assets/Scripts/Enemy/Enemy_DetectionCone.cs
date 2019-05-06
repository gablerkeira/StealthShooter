﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_DetectionCone : MonoBehaviour
{
    public GameObject player;
    public float detectionRange;
    public float visibilityCone;

    Animator animator;
    NavMeshAgent myAgent;

    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        animator = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 relativeVector;
        relativeVector = player.transform.position - transform.position;

        if(Vector3.Distance(transform.position, player.transform.position) < detectionRange)
        {
            if(Vector3.Angle(transform.forward, relativeVector) < visibilityCone)
            {
                animator.SetBool("Caught", true);
                myAgent.SetDestination(transform.position);
                GetComponent<Enemy_Patrol>().enabled = false;
            }
        }
    }
}