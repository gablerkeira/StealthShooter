using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Level_Manager : MonoBehaviour
{
    private static string lastLevel;

    public static  void setLastLevel(string level)
    {
        lastLevel = level;
    }

    public static string getLastLevel()
    {
        return lastLevel;
    }
}
