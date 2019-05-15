using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
    public Text Message;
    public Image Panel;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        Message.GetComponent<Text>().enabled = false;
        Panel.GetComponent<Image>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.GetComponent<Text>().enabled = true;
            Panel.GetComponent<Image>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Message.GetComponent<Text>().enabled = false;
            Panel.GetComponent<Image>().enabled = false;
        }
    }
}
