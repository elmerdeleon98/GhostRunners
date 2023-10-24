using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 0;
    public int batteryJuice = 0;

    public GhostJump skill;

    public static Vector3 lastCheckPointPos = new Vector3(116, 1, -103);

    // Start is called before the first frame update
    void Start()
    {
        // Initialize playerHealth to 10
        playerHealth = 10;
        //Initialize BatteryJuice to 5
        batteryJuice = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <=0)
        {
            Debug.Log("YOU HAVE DIED, GAME OVER!");
            GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
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
            SceneSwitch.instance.switchScene(4);
        }

        //recognises a player touched the exit 1 and switches to next level
        if (other.CompareTag("Exit1"))
        {
            Debug.Log("Player tocuhed exit");
            SceneSwitch.instance.switchScene(1);
        }

        //recognises a player touched the exit 2 and switches to next level
        if (other.CompareTag("Exit2"))
        {
            Debug.Log("Player tocuhed exit");
            SceneSwitch.instance.switchScene(2);
        }

        //recognises a player touched the exit 3 and switches to next level
        if (other.CompareTag("Exit3"))
        {
            Debug.Log("Player tocuhed exit");
            SceneSwitch.instance.switchScene(3);
        }

        //recognises a player was hit by an enemy
        if (other.CompareTag("Enemy"))
        {
            if (skill.isTranslucent==true)
            {
                Debug.Log("Player evaded enemy!");
            }
            else
            Debug.Log("Player was hit by an enemy!");
            playerHealth -= 3;
        }

        //recognises a player picked up a battery
        if(other.CompareTag("Battery"))
        {
            Debug.Log("Picked up battery");
            if(batteryJuice < 5)
            {
                batteryJuice++;
            }
            Debug.Log("You have " + batteryJuice + " uses");
            other.gameObject.SetActive(false);
        }
    }

 

}
