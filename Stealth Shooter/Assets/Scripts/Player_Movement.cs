using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Tooltip("Regular walking speed")]
    public float walkSpeed;
    [Tooltip("Walking speed while crouched")]
    public float crouchSpeed;
    [Tooltip("Rotation speed while crouched")]
    public float crouchRotateSpeed;
    [Tooltip("Regular rotation speed")]
    public float rotateSpeed;
    [Tooltip("Player's rigidbody")]
    public Rigidbody rb;
    [Tooltip("Player's animator")]
    public Animator playerAnimator;

    //Vector3 crouchDown = new Vector3(0, -.5f, 0);
    Vector3 totalForce = Vector3.zero;
    bool crouching = false;
    Camera mainCamera;
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

        if (Input.GetKey(KeyCode.S) && crouching == false)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed; 
        }
        if (Input.GetKey(KeyCode.W) && crouching == false)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (crouching)
            {
                crouching = false;
            }
            else
            {
                crouching = true;
            }
        }

        if (crouching)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * crouchSpeed;
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * crouchRotateSpeed);
        }
        else
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
        }

        transform.position += totalForce * Time.deltaTime;
        //playerAnimator.SetFloat("Velocity", totalForce.magnitude);
    }
}
