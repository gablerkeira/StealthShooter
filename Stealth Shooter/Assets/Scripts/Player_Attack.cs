using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().OnFire += Attack;
    }

    public void Attack(GameObject enemyToKill)
    {
        //start animation for enemy takedown
        Destroy(enemyToKill);
    }
}