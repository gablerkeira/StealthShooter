using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    public Collider boxCollider;
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnChoke += Choking;
        setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;

        boxCollider.enabled = true;
    }

    public void Die()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnChoke -= Choking;
        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);

        if (gameObject != null)
        {
            Destroy(gameObject, 6f);
        }
    }

    public void Choking(GameObject enemyToChoke)
    {
        
        if (this.gameObject == enemyToChoke)
        {
            if (enemyToChoke.GetComponent<Enemy_Patrol>() != null)
            {
                Animator enemyAnimator = enemyToChoke.GetComponent<Animator>();
                enemyAnimator.enabled = false;
                enemyToChoke.GetComponent<NavMeshAgent>().destination = transform.position;
                enemyToChoke.GetComponent<Enemy_Patrol>().enabled = false;
                enemyToChoke.GetComponent<Enemy_DetectionCone>().enabled = false;
            }
            else
            {
                Animator enemyAnimator = enemyToChoke.GetComponent<Animator>();
                enemyAnimator.enabled = false;
                enemyToChoke.GetComponent<NavMeshAgent>().destination = transform.position;
                enemyToChoke.GetComponent<Enemy_DetectionCone>().enabled = false;
            }
        }
    }

    void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }


    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }

    private void OnDestroy()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnDie -= Die;
    }
}
