using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsPanel : MonoBehaviour
{
    public GameObject Panel;

    public static bool isOn;

    private void Start()
    {
        isOn = false;
    }

    private void Update()
    {
        if (isOn == true)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
