using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public Player player;
    public TMP_Text playerHealthText;
    //public TMP_Text playerBatteryText;

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Player Health:" + player.playerHealth;
        //playerBatteryText.text = "Charge Count:" + player.batteryJuice;
    }
}
