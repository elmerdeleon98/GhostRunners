using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //checks if the flashlight detects the enemy
        if(other.CompareTag("Enemy"))
        {
            //deactivates the enemy if detected.
            other.gameObject.SetActive(false);
            Debug.Log("enemy was attacked");
        }
    }
}
