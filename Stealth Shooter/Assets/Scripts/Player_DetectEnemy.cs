using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DetectEnemy : MonoBehaviour
{
    [Tooltip("Player's attack script")] Player_Attack playerScript;

    private void Awake()
    {
        playerScript = transform.GetComponent<Player_Attack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerScript.AddEnemy(other.gameObject);
            playerScript.OnDie += other.GetComponent<Enemy_Controller>().Die;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerScript.RemoveEnemy(other.gameObject);
            playerScript.OnDie -= other.GetComponent<Enemy_Controller>().Die;
        }
    }
}
