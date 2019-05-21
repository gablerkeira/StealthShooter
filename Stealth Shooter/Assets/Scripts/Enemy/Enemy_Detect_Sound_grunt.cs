using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Detect_Sound_grunt : MonoBehaviour, IEnemy_Detect_Sound
{
    public NavMeshAgent myAgent;
    public float radiusOfSound;
    public Animator animator;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnShoot += GoToPoint;
    }
    public void GoToPoint(Vector3 waypointPosition)
    {
        if (myAgent != null)
        {
            if (Vector3.Distance(transform.position, waypointPosition) <= radiusOfSound)
            {

                myAgent.SetDestination(waypointPosition);
                StartCoroutine(StopAtSound());
            }
        }
    }

    IEnumerator StopAtSound()
    {
        if (myAgent != null)
        {
            while (Vector3.Distance(myAgent.transform.position, myAgent.destination) > 1)
            {
                yield return null;
            }

            myAgent.isStopped = true;
            animator.SetBool("Walk", false);
            yield return new WaitForSeconds(5f);
            myAgent.isStopped = false;
            animator.SetBool("Walk", true);
        }
    }

    private void OnDestroy()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnShoot -= GoToPoint;
    }
}
