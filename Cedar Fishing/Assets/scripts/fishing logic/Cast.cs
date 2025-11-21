using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Cast : MonoBehaviour
{
    InputAction interactAction;
    InputAction moveAction;
    InputAction click;
    InputAction rightClick;

    private float movementX;
    private float movementY;

    private MonoBehaviour move;
    private MonoBehaviour fishOn;

    public GameObject bobberGuide;
    public GameObject bobber;
    public GameObject Line;

    Animator animator;

    Rigidbody rb;
    Rigidbody bobberGuiderb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        moveAction = InputSystem.actions.FindAction("Move");
        click = InputSystem.actions.FindAction("Attack");
        rightClick = InputSystem.actions.FindAction("RightClick");

        move = GetComponent<Example>();
        fishOn = GetComponent<fishOn>();

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        bobberGuiderb = bobberGuide.GetComponent<Rigidbody>();
        bobberGuiderb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        // If E is pressed disable movement, and set the bobber guide to be active,and at your current position
        // The bobber guide is a placeholder for the actual bobber that you will cast later
        if (interactAction.triggered)
        {
            move.enabled = false;

            rb.linearVelocity = new Vector3(0, 0, 0);

            animator.SetBool("isWalking", false);
            animator.SetBool("backwards", false);
            animator.SetBool("isRunning", false);

            bobberGuide.transform.position = this.transform.position;
            bobberGuide.transform.position += new Vector3(0, 10, 0);
            //bobberGuide.transform.position = new Vector3(bobberGuide.transform.position.x, 16, bobberGuide.transform.position.z);

            bobberGuide.SetActive(true);
        }

        // Check to see if the move script is disabled
        // If it is, then you are able to move the bobber guide with WASD
        if (move.enabled == false)
        {



            Vector2 moveValue = moveAction.ReadValue<Vector2>();

            movementX = moveValue.x;
            movementY = moveValue.y;

            Vector3 movement = (transform.right * movementX + transform.forward * movementY).normalized;
            Vector3 targetVelocity = movement * 50;

            // Apply movement to the Rigidbody
            Vector3 velocity = bobberGuiderb.linearVelocity;
            velocity.x = targetVelocity.x;
            velocity.z = targetVelocity.z;

            float distance = Vector3.Distance(this.transform.position, bobberGuide.transform.position);

            if (distance < 150)
            {
                bobberGuiderb.linearVelocity = velocity;
            }
            if (distance > 150)
            {
                bobberGuide.transform.position = Vector3.MoveTowards(bobberGuide.transform.position, this.transform.position, 1);
            }

            Vector3 gravity = new Vector3(0, -100, 0);
            bobberGuiderb.AddForce(gravity);



            // Actual cast of the bobber with a left click of the mouse
            // The bobber will go to where the bobber guide is
            if (click.triggered && fishOn.enabled == false && animator.GetBool("isCasting") == false)
            {
                animator.SetBool("isCasting", true);
                Invoke("renderLine", 2.2f);
            }

            if (rightClick.triggered)
            {
                move.enabled = true;
                bobberGuide.SetActive(false);

                animator.SetBool("isCasting", false);

                Line.SetActive(false);
                bobber.SetActive(false);

                fishOn.enabled = false;

                CancelInvoke("renderLine");
            }


        }


    }

    void renderLine()
    {
        bobberGuide.SetActive(false);
        bobber.SetActive(true);
        bobber.transform.position = bobberGuide.transform.position;
        Line.SetActive(true);
        fishOn.enabled = true;
    }
}
