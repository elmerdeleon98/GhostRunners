using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //checkpoints
    public GameObject CheckPointPrefab;
    public GameObject CheckPointPrefab2;
    public GameObject CheckPointPrefab3;
    public GameObject CheckPointPrefab4;
    public GameObject CheckPointPrefab5;

    public static Vector3 currentCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentCheckpoint = transform.position; //saves the location of the checkpoint. 
            //Player.playerPos = currentCheckpoint; //Use this to actually teleport. 
            Debug.Log("check point hit");
        }
    }
}
