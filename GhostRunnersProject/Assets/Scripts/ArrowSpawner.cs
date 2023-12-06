using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform spawnPosition;
    public Transform targetLocation;

    public float spawnRate = 2f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            ShootArrow();
            timer = 0f;
        }

    }
    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, spawnPosition.position, Quaternion.identity);

        Vector3 direction = (targetLocation.position - spawnPosition.position).normalized;
        
        arrow.transform.rotation = Quaternion.LookRotation(direction);
        
        Arrow arrowMovement = arrow.GetComponent<Arrow>();

        if (arrowMovement != null)
        {
            arrowMovement.SetTrajectory(targetLocation.position);
        }
    }
}

