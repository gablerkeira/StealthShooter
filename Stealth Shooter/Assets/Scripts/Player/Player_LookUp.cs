﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LookUp : MonoBehaviour
{
    float rotationY = 0f;
    float sensitivityY = 5f;
    float minY = -60f;
    float maxY = 60f;
    public GameObject mainCamera;

    void Update()
    {
        rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        //Debug.Log(rotationY);
        //mainCamera.transform.Rotate(new Vector3(rotationY, 0, 0));
        //mainCamera.transform.localEulerAngles = new Vector3(rotationY, 0, 0);
        mainCamera.transform.eulerAngles = new Vector3(rotationY, 0, 0);
 
    }
}
