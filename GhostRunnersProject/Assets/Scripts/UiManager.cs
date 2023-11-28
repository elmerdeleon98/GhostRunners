using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TMP_Text playerHealthText;
    public TMP_Text playerBatteryText;
    public TMP_Text playerLivesText;
    public TMP_Text playerCoinsText;

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Player Health:" + Player.playerHealth;
        playerBatteryText.text = "Charge Count:" + Player.batteryJuice;
        playerLivesText.text = "Lives:" + PlayerController.lives;
        playerCoinsText.text = "Coins:" + DoorUnlock.coinCount;
    }
 
}
