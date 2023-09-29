using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
//Garcia, Mario
//9/29/23
//Moves the player/camer and applies gravity. Lets the player run using [left shift]
public class PlayerController : MonoBehaviour
{   
    private Vector3 movementInput;
    private Vector3 velocity;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    public float speed = 6f;
    public float walkingSpeed = 6f;
    public float sprintSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private bool isSprinting;

    void Start()
    {
        //Hiding the cursor on start (press escape to get back cursor)
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
        Move();
    }

    private void Move()
    {
        //getting the input from the player and calling the move function
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        //checking if the player is on the ground
        if(controller.isGrounded)
        {   
            //makes it so that when you fall off you don't instantly fall at max gravity. 
            velocity.y = -1f;
        }
        else
        {   
            //pulls the player down using gravity 
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        //initializing temporary variable that holds the velocity
        float sprintSpeed = 10f;
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        
        //checks to see if the player is sprinting and changes the speed of the player. 
        switch (isSprinting)
        {
            case true:
            speed = sprintSpeed;
            break;
            default:
            speed = walkingSpeed;
            break;
        }

        //Checks to see if the player is moving
        if(movementInput.magnitude >= 0.1f)
        {
            //getting the direction of the player inputs 
            Vector3 moveVec = transform.TransformDirection(movementInput);

            

            //move the player according to the cameras direction
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //moving the player
            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction * speed * Time.deltaTime);
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
