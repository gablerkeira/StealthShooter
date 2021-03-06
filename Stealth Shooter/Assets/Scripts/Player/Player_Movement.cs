﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    #region Walking Variables
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
    #endregion

    Vector3 totalForce = Vector3.zero;
    public bool crouching = false;
    public Action OnFire = delegate { };

    [Tooltip("First Person Camera View")]
    public GameObject mainCamera;
    [Tooltip("Third Person Camera View")]
    public GameObject tpCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _Level_Manager.setLastLevel(SceneManager.GetActiveScene().name);
        playerAnimator = gameObject.GetComponent<Animator>();
        mainCamera.gameObject.SetActive(true);

        tpCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        totalForce = Vector3.zero;

        #region Moving Backwards
        if (Input.GetKey(KeyCode.S) && crouching == false)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed; 
        }
        #endregion

        #region Moving Forwards
        if (Input.GetKey(KeyCode.W) && crouching == false)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        }
        #endregion

        #region Crouching
        if (Input.GetKeyDown(KeyCode.C))
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

        if (crouching == false && playerAnimator.GetBool("SneakAnim") == true)
        {
            playerAnimator.SetBool("SneakAnim", false);
        }

        if (crouching)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * crouchSpeed;
            totalForce += transform.right * Input.GetAxis("Horizontal") * crouchSpeed;

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * crouchRotateSpeed);

            mainCamera.gameObject.SetActive(false);
            tpCamera.gameObject.SetActive(true);
            if (crouching == true)
            {
                if (Input.anyKey == false)
                {
                    playerAnimator.SetBool("SneakAnim", false);
                }
                else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    playerAnimator.SetBool("SneakAnim", true);
                }
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);

            totalForce += transform.right * Input.GetAxis("Horizontal") * walkSpeed;

            mainCamera.gameObject.SetActive(true);
            tpCamera.gameObject.SetActive(false);
        }
        #endregion

        if (crouching == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
            {
                OnFire();
            }
        }

        transform.position += totalForce * Time.deltaTime;
    }
}