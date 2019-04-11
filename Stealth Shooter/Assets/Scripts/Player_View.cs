using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_View : MonoBehaviour
{
    public bool crouching = false;

    public GameObject mainCamera;
    public GameObject tpCamera;

    private void Start()
    {
        mainCamera.gameObject.SetActive(true);
        tpCamera.gameObject.SetActive(false);
    }
    private void Update()
    {
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

        if (crouching)
        {
            mainCamera.gameObject.SetActive(false);
            tpCamera.gameObject.SetActive(true);
        }
        else
        {
            mainCamera.gameObject.SetActive(true);
            tpCamera.gameObject.SetActive(false);
        }
    }
}
