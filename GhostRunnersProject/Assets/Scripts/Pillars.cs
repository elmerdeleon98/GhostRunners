using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{
    public HealthBar healthBar;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            BossEnemy.health = BossEnemy.health - 3;
            healthBar.SetHealth(BossEnemy.health);

            Debug.Log(BossEnemy.health);   
            Destroy(this.gameObject);
        }
    }
}
