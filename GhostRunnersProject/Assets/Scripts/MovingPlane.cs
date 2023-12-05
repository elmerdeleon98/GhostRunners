using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed = 2f;

    private bool movingToEnd = true;

    void Update()
    {
        MovePlane();
    }

    void MovePlane()
    {
        float step = speed * Time.deltaTime;

        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);

            if (transform.position == endPos.position)
            {
                movingToEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, step);

            if (transform.position == startPos.position)
            {
                movingToEnd = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
