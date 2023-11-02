using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuideUI : MonoBehaviour
{
    public Canvas canvas;

    

    public void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            canvas.enabled = true;
        }
    }

    public void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            canvas.enabled = false;
        }
    }
    
}
