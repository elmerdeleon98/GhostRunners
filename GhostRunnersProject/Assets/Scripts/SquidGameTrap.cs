using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidGameTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //recognizes a player touched the fake trap
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
