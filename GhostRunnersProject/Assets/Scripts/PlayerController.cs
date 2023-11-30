using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float walkingSpeed = 6f;//initial is 6
    public float sprintSpeed = 10f;//initial is 10 
    public float gravity = -9.81f;
    [SerializeField] private bool isSprinting;

    //Flashlight Variables
    public int uses;
    public bool isOn;
    public int maxUses;

    //Respawning
    private Vector3 startPosition;
    public static int lives = 3;
    public int fallDepth;

    //Flying Variables
    private bool isFloating;
    public float remainingFloatDuration;
    public float maxFloatDuration = 5f;

    public FloatBar floatBar;

    void Start()
    {
        //Hiding the cursor on start (press escape to get back cursor)
        Cursor.lockState = CursorLockMode.Locked;

        remainingFloatDuration = maxFloatDuration;
        floatBar.MaxDuration(maxFloatDuration);
        //stores the start position of the Player when the scene starts
        //startPosition = transform.position;
    }

    void Update()
    {
        Physics.SyncTransforms();

        Move();
        Float();
        Attack();
        Instructions();
    }
    // Set the isFloating to true and set the maximum float duration
    private void StartFloating()
    {
        isFloating = true;
        remainingFloatDuration = 5.0f; 
        StartCoroutine(FloatingCoroutine());
    }

    private void StopFloating()
    {
        isFloating = false;
        StopCoroutine(FloatingCoroutine());
    }


    private IEnumerator FloatingCoroutine()
    {
        //saving original gravity and changing it 
        float originalGravity = gravity;
        gravity = 2f;

        //allow the player to fly while the floatduration is greater than the timer. 
        while (isFloating)
        {
            velocity.y = Mathf.Lerp(0f, 10f, (maxFloatDuration - remainingFloatDuration) / maxFloatDuration);
            yield return new WaitForEndOfFrame();
        }
        gravity = originalGravity;
    }

    public void Float()
    {
        floatBar.SetDuration(remainingFloatDuration);
        // Check if the player is holding the spacebar to control floating
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isFloating && controller.isGrounded)
            {
                StartFloating();
            }
        }
        else
        {
            if (isFloating)
            {
                StopFloating();
            }
        }

        if (isFloating)
        {
            // Decrease the remaining float duration and stop floating when it reaches 0
            remainingFloatDuration -= Time.deltaTime;
            if (remainingFloatDuration <= 0f)
            {
                StopFloating();
            }
        }

    }
   
    //if the player left clicks the flashlight will turn on. 
    private void Attack()
    {
        isOn = Input.GetKey(KeyCode.Mouse0);

        if (isOn && Player.batteryJuice >0)
        {
            flashlight.SetActive(true);
        }
        else
        {
            flashlight.SetActive(false);
        }
    }

    //if the player presses C they will bring up the controls panel
    private void Instructions()
    {
        if (Input.GetKey(KeyCode.C))
        {
            ControlsPanel.isOn = true;
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.X))
        {
            ControlsPanel.isOn = false;
            Time.timeScale = 1;
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
            velocity.y -= -1f * Time.deltaTime;
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
        //moves the player 
        controller.Move(velocity * Time.deltaTime);
        /*
        //checks to see if the player falls off the platform
        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
        */
    }

    //Respawns the player at the start of the level
    /*
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
    }
    */
}
