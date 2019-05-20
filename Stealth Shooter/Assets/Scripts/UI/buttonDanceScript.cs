using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDanceScript : MonoBehaviour
{
    public float DancersX = 2.4f;
    public float DancersY = 15;
    public float DancersZ = 3;

    public void Mouse()
    {
        GameObject.Find("Dancers").transform.localPosition = new Vector3(DancersX, DancersY, DancersZ);
    }
}
