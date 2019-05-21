using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YachtToWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("FinalCutScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
