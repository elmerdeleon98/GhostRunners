using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize playerHealth to 10
        playerHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //recognises a player picked up health pack and heals player by 5
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPack"))
        {
            Debug.Log("Player picked up a health pack.");
            playerHealth += 5;
            other.gameObject.SetActive(false);
        }
    }

}
