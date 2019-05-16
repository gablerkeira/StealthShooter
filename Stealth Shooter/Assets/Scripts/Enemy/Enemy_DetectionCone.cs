using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_DetectionCone : MonoBehaviour
{
    public GameObject player;
    public float detectionRange;
    public float visibilityCone;
    public Scene currentScene;

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
        currentScene = SceneManager.GetActiveScene();
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
                player.GetComponent<Player_Movement>().enabled = false;
                StartCoroutine(LoadScene());

            }
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(currentScene.name);
    }
}
