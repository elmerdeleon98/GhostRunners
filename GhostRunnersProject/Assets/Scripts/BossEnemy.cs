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
        //random direction for the projectile
        Vector3 randomDirection = Random.onUnitSphere;

        randomDirection.y = 0f;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        projectile.GetComponent<ProjectileController>().speed = projectileSpeed;
    }
}
