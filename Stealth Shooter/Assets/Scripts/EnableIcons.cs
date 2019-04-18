using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableIcons : MonoBehaviour
{
    public bool GotGun;
    public bool GotKey;
    public bool CanWire;
    public bool GotHook;

    public RawImage SoundGun;
    public RawImage Key;
    public RawImage Wire;
    public RawImage GrapplingHook;

    // Update is called once per frame
    void Update()
    {
        //Checks to see if player has the SoundGun
        if (GotGun == true)
        {
            SoundGun.GetComponent<RawImage>().enabled = true;
        }
        else
        {
            SoundGun.GetComponent<RawImage>().enabled = false;
        }

        //Checks to see if player can assassinate enemy
        if (CanWire == true)
        {
            Wire.GetComponent<RawImage>().enabled = true;
        }
        else
        {
            Wire.GetComponent<RawImage>().enabled = false;
        }

        //Checks to see if player has obtained the key
        if (GotKey == true)
        {
            Key.GetComponent<RawImage>().enabled = true;
        }
        else
        {
            Key.GetComponent<RawImage>().enabled = false;
        }

        //Checks to see if player has grappling hook
        if (GotHook == true)
        {
            GrapplingHook.GetComponent<RawImage>().enabled = true;
        }
        else
        {
            GrapplingHook.GetComponent<RawImage>().enabled = false;
        }
    }
}
