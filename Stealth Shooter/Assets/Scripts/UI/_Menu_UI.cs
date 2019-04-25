using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _Menu_UI : MonoBehaviour
{
    public void _Exit_Game()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }

    public void _Start_Game()
    {
        SceneManager.LoadScene("The Warehouse");
    }

    public void _Credit_Scene()
    {
        SceneManager.LoadScene("Credits");
    }
}
