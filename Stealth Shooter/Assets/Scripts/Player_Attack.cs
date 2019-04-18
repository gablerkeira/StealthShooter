using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Action OnDie = delegate { };
    [Tooltip("List of nearby enemies to the player")]
    public List<GameObject> nearbyEnemy;

    private void Awake()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().OnFire += Attack;
    }

    void Start()
    {
        nearbyEnemy = new List<GameObject>();
    }

    public void AddEnemy(GameObject obj)
    {
        nearbyEnemy.Add(obj);
    }

    public void RemoveEnemy(GameObject obj)
    {
        nearbyEnemy.Remove(obj);
    }


    public void Attack()
    {
        if (nearbyEnemy.Count > 0)
        {
            //start animation for enemy takedown
            OnDie();
        }
    }
}