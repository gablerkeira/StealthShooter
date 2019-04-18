using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Attack>().OnDie += Die;
    }

    public void Die()
    {

    }
}
