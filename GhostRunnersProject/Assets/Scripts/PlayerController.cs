using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering;
//Garcia, Mario
//9/23/23
//Moves the player and applies gravity. 
public class PlayerController : MonoBehaviour
{   
    private Vector3 movementInput;
    private Vector3 velocity;
    [SerializeField] private CharacterController controller;
    [SerializeField]private float speed;
    [SerializeField]private float gravity = -9.81f;

    void Update()
    {   
        //getting the input from the player and calling the move function
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Move();
    }

    private void Move()
    {
        //getting the direction of the player inputs 
        Vector3 moveVec = transform.TransformDirection(movementInput);

        //checking if the player is on the ground
        if(controller.isGrounded)
        {   
            //makes it so that when you fall off you don't instantly fall at max gracvity. 
            velocity.y = -1f;
        }
        else
        {   
            //pulls the player down using gravity 
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        //moving the player 
        controller.Move(moveVec * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
        
    }
}
