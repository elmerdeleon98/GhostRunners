using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //collectibles
    public static int playerHealth = 10;
    public static int batteryJuice = 5;

    //skills
    public GhostJump skill;

    //scene
    public SceneManagement sceneScript;

    //checkpoint
    public Transform DefaultSpawnPos;
    public static Vector3 checkPointPos;
    public static bool isDead = false;

    private void Start()
    {
        checkPointPos = DefaultSpawnPos.transform.position;
    }

    public void Update()
    {

        if (isDead)
        {
            Debug.Log("DIED");
            Debug.Log(checkPointPos);
            Teleport(checkPointPos);
            isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //recognises a player picked up health pack and heals player by 5
        if (other.CompareTag("HealthPack"))
        {
            Debug.Log("Player picked up a health pack.");
            playerHealth += 5;
            other.gameObject.SetActive(false);
        }

        //recognises a player picked up the magical orb and switches to winScene
        if (other.CompareTag("MagicOrb"))
        {
            Debug.Log("Player picked up the Magic Orb!");
            SceneSwitch.instance.switchScene(6);
        }

        //recognises a player touched the exit 1 and switches to next level
        if (other.CompareTag("Exit1"))
        {
            Debug.Log("Player tocuhed exit");
            SceneSwitch.instance.switchScene(3);
        }

        //recognises a player touched the exit 2 and switches to next level
        if (other.CompareTag("Exit2"))
        {
            Debug.Log("Player tocuhed exit");
            SceneSwitch.instance.switchScene(4);
        }

        //recognises a player touched the exit 3 and switches to next level
        if (other.CompareTag("Exit3"))
        {
            Debug.Log("Player tocuhed exit");
            SceneSwitch.instance.switchScene(5);
        }

        //recognises a player was hit by an enemy
        if (other.CompareTag("Enemy"))
        {
            if (skill.isTranslucent==true)
            {
                Debug.Log("Player evaded enemy!");
            }
            else
            {
                Debug.Log("Player was hit by an enemy!");
                EnemyFollow.hitPlayer = true;
                playerHealth -= 3;
            }
        }

        //recognises a player hitting the death zone
        if (other.CompareTag("DeathZone"))
        {
            sceneScript.playerHitDeath();
        }


        //recognises a player was hit by a spike trap
        if (other.CompareTag("Spikes"))
        {
            if (skill.isTranslucent == true)
            {
                Debug.Log("Player evaded Trap!");
            }
            else
            {
                Debug.Log("Player was hit by trap!");
                playerHealth -= 5;
            }
        }

        //recognises a player picked up a battery
        if (other.CompareTag("Battery"))
        {
            Debug.Log("Picked up battery");
            if(batteryJuice < 10)
            {
                batteryJuice++;
            }
            if (batteryJuice < 0)
            {
                batteryJuice = 0;
            }
            Debug.Log("You have " + batteryJuice + " uses");
            other.gameObject.SetActive(false);
        }

        if(other.CompareTag("Coin"))
        {
            DoorUnlock.coinCount++;
            other.gameObject.SetActive(false);
        }

        //recognises a player was hit by an arrow
        if(other.CompareTag("Arrow"))
        {
            if(skill.isTranslucent == true)
            {
                Debug.Log("Player evaded Trap!");
            }
            else
            {
                Debug.Log("Player was hit by an arrow!");
                playerHealth -= 5;
            }

        }

        //checks if health exceeds
        if (playerHealth > 20)
        {
            playerHealth = 20;
        }

        if(other.CompareTag("Light"))
        {
            //coroutine that damages the player every x seconds whil inside the light
            InvokeRepeating("DamagePerSecond", 2f, 4f);
        }

        if(other.CompareTag("CheckPoint1"))
        {
            checkPointPos = transform.position;

            Debug.Log("Checkpoint Saved to :" + checkPointPos);
        }

        if(other.CompareTag("Wrong"))
        {
            playerHealth -= 5;
        }

        if (other.CompareTag("BossProjectile"))
        {
            playerHealth -= 5;
        }
    }
    
   

    public void Teleport(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void DamagePerSecond()
    {
        playerHealth--;
    }
}
