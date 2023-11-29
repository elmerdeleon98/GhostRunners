using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.CompareTag("Enemy"))
            {
                //deactivates the enemy if detected.
                other.gameObject.SetActive(false);
            }
        }
    }
    
}
