using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //player script access
    public Player playerScript;
    private void OnTriggerEnter(Collider other)
    {
        //checks if the flashlight detects the enemy
        if(other.CompareTag("Enemy"))
        {
            //deactivates the enemy if detected.
            other.gameObject.SetActive(false);
            playerScript.batteryJuice--;
            Debug.Log("enemy was attacked");

        }
    }
}
