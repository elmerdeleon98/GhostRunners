using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //light variables
    public GameObject moveLight;
    public Transform targetPosition;
    public float moveSpeed = 1f;
    private Vector3 endPosition;
    private bool isMoving = false;

    //timer variables
    static public float timer = 300f;

    // Update is called once per frame
    void Update()
    {
        //  Vector3 moveLight;

        timer -= Time.deltaTime;

        //Debug.Log(timer);

        if (timer < 0)
        {
            MoveLight();
        }

    }

    public void MoveLight()
    {
        endPosition = moveLight.transform.position + Vector3.up * 2.0f;
        isMoving = true;

        if(isMoving) 
        {
            moveLight.transform.position = Vector3.Lerp(moveLight.transform.position, endPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(moveLight.transform.position, endPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }

}
