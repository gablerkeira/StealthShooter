using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int destPoint = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if(waypoints.Length == 0)
        {
            return;
        }

        agent.destination = waypoints[destPoint].position;

        destPoint = (destPoint + 1) % waypoints.Length;
    }

    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}
