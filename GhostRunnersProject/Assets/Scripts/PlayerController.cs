using JetBrains.Annotations;
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
    //Movement and Camera Variables
    private Vector3 movementInput;
    private Vector3 velocity;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    public float speed = 6f;
    public float walkingSpeed = 6f;
    public float sprintSpeed = 10f;
    public float gravity = -9.81f;
    [SerializeField] private bool isSprinting;

    //Flashlight Variables
    public int uses;
    public bool isOn;
    public int maxUses;

    //Respawning
    private Vector3 startPosition;
    public int lives = 3;
    public int fallDepth;

    //Flying Variables
    private bool isFloating;
    private float floatDuration = 3.0f;

    void Start()
    {
        gravity = -9.81f;

        //Hiding the cursor on start (press escape to get back cursor)
        Cursor.lockState = CursorLockMode.Locked;

        //stores the start position of the Player when the scene starts
        startPosition = transform.position;
    }

    void Update()
    {
        Move();
        Attack();
        Fly();
    }

    public void Fly()
    {
        //if the player presses spacebar they will begin to fly
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            StartCoroutine(FloatingCoroutine());
        }
    }

    private IEnumerator FloatingCoroutine()
    {
        //saving original gravity and changing it 
        float originalGravity = gravity;
        gravity = 2f;
        float timer = 0f;

        //allow the player to fly while the floatduration is greater than the timer. 
        while (timer < floatDuration)
        {
            velocity.y = Mathf.Lerp(0f, 10f, timer / floatDuration);

            timer += Time.deltaTime;

            yield return null;
        }
        gravity = originalGravity;
    }
    //if the player left clicks the flashlight will turn on. 
    private void Attack()
    {
        isOn = Input.GetKey(KeyCode.Mouse0);

        if (isOn)
        {
            flashlight.SetActive(true);
        }
        else
        {
            flashlight.SetActive(false);
        }
    }


    private void Move()
    {
        //getting the input from the player and calling the move function
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        //checking if the player is on the ground
        if (controller.isGrounded)
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
        if (movementInput.magnitude >= 0.1f)
        {
            //getting the direction of the player inputs 
            Vector3 moveVec = transform.TransformDirection(movementInput);

            //move the player according to the cameras direction
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //moving the player's direction
            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction * speed * Time.deltaTime);

        }
        //(new change)
        //moves the player 
        controller.Move(velocity * Time.deltaTime);
        //(new change)

        //checks to see if the player falls off the platform
        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    //Respawns the player at the start of the level
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
    }
}
