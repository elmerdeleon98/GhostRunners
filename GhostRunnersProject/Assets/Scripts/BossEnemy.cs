using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float shootingInterval = 2f;
    public float projectileSpeed = 7f;

    void Start()
    {
        InvokeRepeating("ShootProjectile", 0f, shootingInterval);
    }

    void ShootProjectile()
    {
        // Calculate a random direction for the projectile
        Vector3 randomDirection = Random.onUnitSphere;

        // Calculate the spawn position based on the random direction
        Vector3 randomSpawnPosition = projectileSpawnPoint.position + randomDirection * 5f; // Adjust the distance as needed

        // Ensure the projectiles stay in the horizontal plane
        randomSpawnPosition.y = projectileSpawnPoint.position.y;

        // Calculate the direction from the random position to the player
        Vector3 direction = (projectileSpawnPoint.position - randomSpawnPosition).normalized;

        // Instantiate the projectile and set its velocity
        GameObject projectile = Instantiate(projectilePrefab, randomSpawnPosition, Quaternion.LookRotation(direction));
        projectile.GetComponent<ProjectileController>().speed = projectileSpeed;
    }
}
