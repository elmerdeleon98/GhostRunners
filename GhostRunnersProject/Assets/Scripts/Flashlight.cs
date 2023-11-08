using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    
    public Transform spawnPos;
    public GameObject healthPack;
    public GameObject battery;

    public float dropProbability = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        //checks if the flashlight detects the enemy
        if(other.CompareTag("Enemy"))
        {
            //deactivates the enemy if detected.
            other.gameObject.SetActive(false);
            Player.batteryJuice--;
            RandomDrop();
            Debug.Log("enemy was attacked");

        }
    }

    private void RandomDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        int randomDrop = Random.Range(0, 2);
        bool drop = randomValue <= dropProbability;

        if(drop)
        {
            switch (randomDrop) 
            {  
                case 0:
                    //instantiate drop
                    Instantiate(healthPack, spawnPos.position, spawnPos.rotation);
                    break;
                case 1:
                    //instantiate drop
                    Instantiate(battery, spawnPos.position, spawnPos.rotation);
                    break;
                default:
                    break;               
            }
            Debug.Log("Item Dropped");

        }
    }
}
