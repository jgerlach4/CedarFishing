using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Example : MonoBehaviour
{
    // These variables are to hold the Action references
    InputAction moveAction;
    InputAction jumpAction;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private float movementZ;

    public float speed = 10;

    public float runSpeed = 20;
    private bool running = false;

    Animator animator;

    private void Start()
    {
        // Find the references to the "Move" and "Jump" actions
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        //! added
        moveAction.Enable();
        jumpAction.Enable();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Read the "Move" action value, which is a 2D vector
        // and the "Jump" action state, which is a boolean value

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // ! added
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool isWalking = animator.GetBool("isWalking");

        bool runningPressed = Input.GetKey(KeyCode.LeftShift);
        bool isRunning = animator.GetBool("isRunning");

        bool castPressed = Input.GetKey(KeyCode.E);
        bool isCasting = animator.GetBool("isCasting");


        // your movement code here

        movementX = moveValue.x;
        movementY = moveValue.y;

        // ! added
        //walking
        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        // running
        if (forwardPressed && runningPressed)
        {
            animator.SetBool("isRunning", true);
            running = true;
        }
        if (!forwardPressed || !runningPressed)
        {
            animator.SetBool("isRunning", false);
            running = false;
        }

        //casting
        if (!forwardPressed && !runningPressed && castPressed)
        {
            animator.SetBool("isCasting", true);
        }
        if (!castPressed || forwardPressed || runningPressed)
        {
            animator.SetBool("isCasting", false);
        }

    }

    void FixedUpdate()
    {
        float currentSpeed = running ? runSpeed : speed;

        Vector3 movement = (transform.right * movementX + transform.forward * movementY).normalized;
        Vector3 targetVelocity = movement * currentSpeed;

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;

        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.linearVelocity = velocity;
        
    }

}