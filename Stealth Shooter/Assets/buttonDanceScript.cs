using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDanceScript : MonoBehaviour
{
    public float DancersX = 2.4f;
    public float DancersY = 15;
    public float DancersZ = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Mouse()
    {
        GameObject.Find("Dancers").transform.localPosition = new Vector3(DancersX, DancersY, DancersZ);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
