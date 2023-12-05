using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 20f;
    private Transform target; //player's transform
    public float lifespan = 4f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
        {
            Debug.LogError("Player not found!");
        }

        //velocity towards player
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;

        Destroy(gameObject, lifespan);
    }

    void Update()
    {
       
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); //destroys the projectile
        }
    }
}
