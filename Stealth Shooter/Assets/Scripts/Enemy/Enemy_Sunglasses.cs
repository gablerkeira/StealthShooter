using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sunglasses : MonoBehaviour
{
    public Material sunglasses;
    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        foreach(GameObject enemy in enemies)
        {
            //enemies.Add(GameObject.FindGameObjectWithTag());
        }
    }
}
