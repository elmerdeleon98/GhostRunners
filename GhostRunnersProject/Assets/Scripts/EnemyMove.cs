using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Horizontal Variables
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public bool goingLeft;

    //left = up
    //right = down

    //Vertical Variables
    public GameObject upPoint;
    public GameObject downPoint;
    private Vector3 upPos;
    private Vector3 downPos;
    public bool goingUp;

    public int enemyType = 0;
    public int speed;

    void Start()
    {
        //initializing horizontal position variables. 
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;

        //initializing vertical position variables
        upPos = upPoint.transform.position;
        downPos = downPoint.transform.position;
    }

    void Update()
    {
        if(enemyType == 0)
        {
            LRMove();
        }
        
        if(enemyType == 1) 
        {
            UDMove();
        }
    }

    private void UDMove()
    {
        if (goingUp)
        {
            if(transform.position.y >= upPos.y)
            {
                goingUp = false;
            }
            else
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.y <= downPos.y)
            {
                goingUp = true; 
            }
            else
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
        }
    }

    private void LRMove()
    {
        if(goingLeft)
        {
            if(transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += (Vector3.left + Vector3.back) * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += (Vector3.right + Vector3.forward) * Time.deltaTime * speed;
            }
        }
    }
}
