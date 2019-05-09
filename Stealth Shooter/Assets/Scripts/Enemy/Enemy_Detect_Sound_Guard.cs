using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Detect_Sound_Guard : MonoBehaviour, IEnemy_Detect_Sound
{
    public NavMeshAgent myAgent;
    public Animator animator;
    public float radiusOfSound;
    Vector3 originalPosition;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnShoot += GoToPoint;
        originalPosition = myAgent.transform.position;
    }

    public void GoToPoint(Vector3 waypointPosition)
    {
        if (Vector3.Distance(transform.position, waypointPosition) <= radiusOfSound)
        {
            animator.SetBool("Walk", true);
            myAgent.SetDestination(waypointPosition);
            StartCoroutine(StopAtSound());
        }
    }

    IEnumerator StopAtSound()
    {
        while (Vector3.Distance(myAgent.transform.position, myAgent.destination) > 1)
        {
            yield return null;
        }

        myAgent.isStopped = true;
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(5f);
        myAgent.isStopped = false;
        myAgent.SetDestination(originalPosition);
    }

    private void OnDestroy()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnShoot -= GoToPoint;
    }
}
