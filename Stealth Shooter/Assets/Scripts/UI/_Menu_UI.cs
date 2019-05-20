using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _Menu_UI : MonoBehaviour
{
    public void _Exit_Game()
    {
        Application.Quit();
    }

    public void _Start_Game()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void _Credit_Scene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void _MainMenu_Scene()
    {
        SceneManager.LoadScene("Menu");
    }

}
