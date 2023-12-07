using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float moveSpeed = 3.0f; // Speed at which the enemy moves towards the player
    public float detectionRadius = 5.0f; // Radius to detect the player
    public Vector3 desiredRotation = new Vector3(0f, 0f, 0f); // Desired rotation in degrees
    public int EnemyType = 0;

    private Rigidbody rb;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Move();

    }

    public void Move()
    {
        // Calculate the direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the distance to the player
        float distanceToPlayer = directionToPlayer.magnitude;



        // Check if the player is within the detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            // Normalize the direction vector to get a unit vector
            directionToPlayer.Normalize();

            // Calculate velocity based on direction and speed
            Vector3 velocity = directionToPlayer * moveSpeed;

            switch (EnemyType)
            {
                case 1:

                    // Set the velocity for the Rigidbody to move the enemy
                    rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
                    break;
                case 2:

                    // Set the velocity for the Rigidbody to move the enemy and allow velocity on the y
                    rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
                    break;
                default:
                    break;
            }
            // Make the enemy always face the player
            transform.LookAt(player);
        }
        else
        {
            // Stop moving if the player is not within the detection radius
            rb.velocity = Vector3.zero;
        }

    }
}
