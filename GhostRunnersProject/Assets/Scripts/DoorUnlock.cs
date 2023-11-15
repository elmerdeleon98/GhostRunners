using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject door;
    public static int coinCount;
    public int requiredCoins;

    public void Start()
    {
        coinCount = 0;
        requiredCoins = 5;
    }

    public void Update()
    {
        if(coinCount == requiredCoins)
        {
            door.SetActive(false);       
        }
    }



}
