using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float walkSpeed;
    public float crouchSpeed;
    public float rotateSpeed;
    Vector3 totalForce = Vector3.zero;
    public Rigidbody rb;
    public Animator playerAnimator;
    public Action OnFire = delegate { };

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        totalForce = Vector3.zero;

        totalForce += transform.right * Input.GetAxis("Horizontal") * walkSpeed;

        if (Input.GetKey(KeyCode.S))
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        }

        transform.position += totalForce * Time.deltaTime;
        //playerAnimator.SetFloat("Velocity", totalForce.magnitude);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
    }
}
