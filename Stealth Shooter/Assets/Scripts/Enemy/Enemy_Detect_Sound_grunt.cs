﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Detect_Sound_grunt : MonoBehaviour, IEnemy_Detect_Sound
{
    public NavMeshAgent myAgent;
    public float radiusOfSound;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnShoot += GoToPoint;
    }
    public void GoToPoint(Vector3 waypointPosition)
    {
        if(Vector3.Distance(transform.position, waypointPosition) <= radiusOfSound)
        {
            myAgent.SetDestination(waypointPosition);
            StartCoroutine(StopAtSound());
        }
    }

    IEnumerator StopAtSound()
    {
        while(Vector3.Distance(myAgent.transform.position, myAgent.destination) > 1)
        {
            yield return null;
        }

        myAgent.isStopped = true;
        yield return new WaitForSeconds(5f);
        myAgent.isStopped = false;
    }
}