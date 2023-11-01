using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowPosRight;
    public Transform arrowPosLeft;
    public float arrowSpeed = 10f;
    public float timeBetweenShots = 2f;
    private float nextFireTime = 0f;
    public bool shootingLeft = false;

    private void Start()
    {
        nextFireTime = Time.time + timeBetweenShots;
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootArrow();
            nextFireTime = Time.time + timeBetweenShots;
        }
    }

    void ShootArrow()
    {
        if (!shootingLeft) 
        {
            // Instantiate a new arrow projectile at the fire point.
            GameObject newarrow = Instantiate(arrowPrefab, arrowPosRight.position, arrowPosRight.rotation);

            // Get the rigidbody of the arrow 
            Rigidbody rb = newarrow.GetComponent<Rigidbody>();

            if (rb != null) 
            {
                
                // Set the velocity of the arrow to make it move forward
                rb.velocity = new Vector3(arrowSpeed, 0, 0);
            }
        }
        else
        {
            // Instantiate a new arrow projectile at the fire point.
            GameObject newarrow = Instantiate(arrowPrefab, arrowPosLeft.position,arrowPosLeft.rotation);
            newarrow.transform.Rotate(0f, 180f, 0f);

            // Get the rigidbody of the arrow 
            Rigidbody rb = newarrow.GetComponent<Rigidbody>();

            if (rb != null)
            {

                // Set the velocity of the arrow to make it move forward
                rb.velocity = new Vector3(-arrowSpeed, 0, 0);
            }
        }
        
    }
}

