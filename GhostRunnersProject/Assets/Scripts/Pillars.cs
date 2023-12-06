using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            BossEnemy.health = BossEnemy.health - 3;
            Debug.Log(BossEnemy.health);   
            Destroy(this.gameObject);
        }
    }
}
