using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 target;
    public float speed = 5f;

    private void Update()
    {

        FollowTrajectory();
    }

    public void SetTrajectory(Vector3 newTarget)
    {
        target = newTarget;
    }

    void FollowTrajectory()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
